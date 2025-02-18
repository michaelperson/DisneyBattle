using DisneyBattle.API.Models;
using DisneyBattle.BLL.Interfaces;
using DisneyBattle.BLL.Mapping;
using DisneyBattle.BLL.Services;
using DisneyBattle.DAL;
using DisneyBattle.DAL.Interfaces;
using Mapster;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//MAspter
builder.Services.AddMapster();

// Configure Mapster
MapsterConfig.Configure(); //Mapper BLL
DisneyBattle.API.Mapping.MapsterConfig.Configure(); //Mapper API

/*Jwt*/
//Je récupère les infos de config de jwt à partir du
// fichier appsettings.json et je stocke le tout 
// dans la classe prévue 
JwtOptions options = builder.Configuration.GetSection("JwtOptions").Get<JwtOptions>();

//Pour pouvoir utiliser le jwtoption il faut l'injecter
builder.Services.AddSingleton(options);

//On configure l'authentication dans les services
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(
            o =>
            {
                //Je vais rechercher ma clé de signature
                byte[] sKey = Encoding.UTF8.GetBytes(options.SigningKey);

                o.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = options.Issuer,
                    ValidAudience = options.Audience,
                    IssuerSigningKey = new SymmetricSecurityKey(sKey)
                };
            }

    );
builder.Services.AddAuthorization();
builder.Services.AddDbContext<DisneyBattleContext>((sp, options) =>
{
#if DEBUG
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisneyBattleDev"));
#else
    options.UseSqlServer(builder.Configuration.GetConnectionString("DisneyBattleProd"));
#endif
});
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUserService, UtilisateurService>();
var corsOrigins = builder.Configuration
            .GetSection("CorsOrigins:AllowedOrigins")
            .Get<string[]>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("DefaultPolicy", policy =>
    {
        policy.WithOrigins(corsOrigins)
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .SetIsOriginAllowedToAllowWildcardSubdomains()  
              .WithExposedHeaders("Content-Disposition");
    });
});

// Configuration spécifique pour le développement
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddCors(options =>
    {
        options.AddPolicy("DevPolicy", policy =>
        {
            policy.AllowAnyOrigin()
                  .AllowAnyMethod()
                  .AllowAnyHeader();
        });
    });
}
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseCors("DevPolicy");
    app.UseSwagger();
    app.UseSwaggerUI();

}
else
{
    app.UseCors("DefaultPolicy");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
