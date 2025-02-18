using DisneyBattle.Front.Services.Interfaces;
using Microsoft.AspNetCore.Components;

namespace DisneyBattle.Front.Pages
{

    public partial class Secured
    {
        [Inject]
        IAuthService _AuthService { get; set; }
        [Inject]
        NavigationManager NavigationManager { get; set; }
        private async Task Logout()
        {
            await _AuthService.Logout();
            NavigationManager.NavigateTo("/login");
        }
    }
}
