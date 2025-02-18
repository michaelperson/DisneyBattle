using Microsoft.AspNetCore.Components;

namespace DisneyBattle.Front.Components.Security
{
    public class RedirectToLogin : ComponentBase
    {
        [Inject]
        protected NavigationManager NavigationManager { get; set; }

        protected override void OnInitialized()
        {
            NavigationManager.NavigateTo($"/login?returnUrl={Uri.EscapeDataString(NavigationManager.Uri)}", true);
        }
    }
}
