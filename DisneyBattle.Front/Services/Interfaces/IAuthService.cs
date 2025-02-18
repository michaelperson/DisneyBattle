using DisneyBattle.Front.Models;

namespace DisneyBattle.Front.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthResult> Login(LoginModel loginModel);
        Task<AuthResult> Register(RegisterModel registerModel);
        Task Logout();
        Task<bool> RefreshToken();
    }
}
