
using DisneyBattle.Front.Services.Interfaces;
using DisneyBattle.Front.Services;
using Microsoft.AspNetCore.Components;

namespace DisneyBattle.Front.Components.UI
{
    
    public partial class JwtDisplay
    {
        private Dictionary<string, string>? claims;
        [Inject]
        IJwtService JwtService { get; set; }
        [Inject]
        ILocalStorageService LocalStorage { get; set; }

        protected override async Task OnInitializedAsync()
        {
            
            string jwtToken = await LocalStorage.GetItemAsync<string>("authToken");
            claims = JwtService.GetClaims(jwtToken);
             
        }
    }
}
