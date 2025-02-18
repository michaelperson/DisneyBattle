using DisneyBattle.Front.Models;
using DisneyBattle.Front.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;
using MudBlazor;
using System.Net.Http.Json;
using static System.Net.WebRequestMethods;

namespace DisneyBattle.Front.Pages
{
    public partial class Login
    {
        private MudForm loginForm;
        private MudForm registerForm;
        private bool loginSuccess;
        private bool registerSuccess;
        private bool isLoading = false;
        private LoginModel loginModel = new();
        private RegisterModel registerModel = new();

        [Inject]
        ISnackbar Snackbar { get; set; }

        [Inject]
        IAuthService _AuthService { get;set; }
        [Inject]
        NavigationManager NavigationManager { get;set; }

        [Inject]
        IJSRuntime JSRuntime { get; set; }

        [Parameter]
        [SupplyParameterFromQuery(Name = "returnUrl")]
        public string ReturnUrl { get; set; }

        private string PasswordMatch(string confirmPassword)
        {
            if (confirmPassword != registerModel.MotDePasse)
                return "Les mots de passe ne correspondent pas!";
            return null;
        }

        private async Task SubmitLogin()
        {
            try
            {
                isLoading = true;
                await loginForm.Validate();
                if (loginSuccess)
                {
                    try
                    {
                        AuthResult ar = await _AuthService.Login(loginModel);
                        if (string.IsNullOrEmpty(ReturnUrl))
                            NavigationManager.NavigateTo("/");
                        else
                            NavigationManager.NavigateTo(ReturnUrl);
                       
                        
                    }
                    catch (Exception ex)
                    {
                        Snackbar.Add("Une erreur est survenue lors de la connexion", Severity.Error);
                    }
                    finally
                    {
                        isLoading = false;
                    }
                }
            }
            catch (Exception ex)
            {
                Snackbar.Add("Une erreur est survenue lors de la connexion", Severity.Error);
                isLoading = false;
            }
        }

        private async Task SubmitRegister()
        {
            await registerForm.Validate();
            if (registerForm.IsValid)
            {
                // Implement your registration logic here
                try
                {
                    isLoading = true;
                    AuthResult ar = await _AuthService.Register(registerModel);
                    Snackbar.Add("Enregistrement réussi", Severity.Success);
                    isLoading = false;
                }
                catch (Exception)
                {
                    Snackbar.Add("Une erreur est survenue lors de la connexion", Severity.Error);
                    isLoading = false;
                }
            }
        }


    }
}
