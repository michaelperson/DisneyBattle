using DisneyBattle.Front.Infrastructure;
using DisneyBattle.Front.Models;
using DisneyBattle.Front.Services.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Json;

namespace DisneyBattle.Front.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private readonly AuthenticationStateProvider _authStateProvider;
        private readonly ILocalStorageService _localStorage; 
        private readonly IHttpClientFactory _httpClientFactory;
        public AuthService(
            HttpClient httpClient,
            AuthenticationStateProvider authStateProvider,
            ILocalStorageService localStorage, IHttpClientFactory ClientFactory)
        {
            _httpClient = httpClient;
            _authStateProvider = authStateProvider;
            _localStorage = localStorage;
            _httpClientFactory = ClientFactory;
        }

        public async Task<AuthResult> Login(LoginModel loginModel)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient("DisneyBattleApi");
                var response = await httpClient.PostAsJsonAsync("Account/Login", loginModel);
                 AuthResult result = await response.Content.ReadFromJsonAsync<AuthResult>();
                
                if (response.IsSuccessStatusCode)
                {
                    await _localStorage.SetItemAsync("Response", true);
                    await _localStorage.SetItemAsync("authToken", result.Access_Token);
                    await _localStorage.SetItemAsync("refreshToken", result.Refresh_Token);

                    ((CustomAuthStateProvider)_authStateProvider)
                        .NotifyUserAuthentication(result.Access_Token);

                    return result;
                }

                return new AuthResult
                {
                    Success = false,
                    Message = result?.Message ?? "Échec de connexion",
                    Errors = result?.Errors ?? new[] { "Une erreur est survenue lors de la connexion" }
                };
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Une erreur est survenue",
                    Errors = new[] { ex.Message }
                };
            }
        }

        public async Task<AuthResult> Register(RegisterModel registerModel)
        {
            try
            {

                HttpClient httpClient = _httpClientFactory.CreateClient("DisneyBattleApi");
                var response = await httpClient.PostAsJsonAsync("Account/Register", registerModel);
                var result = await response.Content.ReadFromJsonAsync<AuthResult>();

                if (response.IsSuccessStatusCode && result.Success)
                {
                    // Optionnel : connexion automatique après inscription
                    //if (!string.IsNullOrEmpty(result.Access_Token))
                    //{
                    //    await _localStorage.SetItemAsync("authToken", result.Access_Token);
                    //    await _localStorage.SetItemAsync("refreshToken", result.Refresh_Token);

                    //    ((CustomAuthStateProvider)_authStateProvider)
                    //        .NotifyUserAuthentication(result.Access_Token);
                    //}

                    return result;
                }

                return new AuthResult
                {
                    Success = false,
                    Message = result?.Message ?? "Échec de l'inscription",
                    Errors = result?.Errors ?? new[] { "Une erreur est survenue lors de l'inscription" }
                };
            }
            catch (Exception ex)
            {
                return new AuthResult
                {
                    Success = false,
                    Message = "Une erreur est survenue",
                    Errors = new[] { ex.Message }
                };
            }
        }

        public async Task Logout()
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient("DisneyBattleApi");
                await httpClient.PostAsync("Account/logout", null);
            }
            catch
            {
                // Même en cas d'échec de l'appel API, on nettoie côté client
            }
            finally
            {
                await _localStorage.RemoveItemAsync("authToken");
                await _localStorage.RemoveItemAsync("refreshToken");
                _httpClient.DefaultRequestHeaders.Authorization = null;
                ((CustomAuthStateProvider)_authStateProvider).NotifyUserLogout();
            }
        }

        public async Task<bool> RefreshToken()
        {
            try
            {
                var token = await _localStorage.GetItemAsync<string>("authToken");
                var refreshToken = await _localStorage.GetItemAsync<string>("refreshToken");

                if (string.IsNullOrEmpty(token) || string.IsNullOrEmpty(refreshToken))
                    return false;

                var refreshRequest = new
                {
                    Token = token,
                    RefreshToken = refreshToken
                };
                HttpClient httpClient = _httpClientFactory.CreateClient("DisneyBattleApi");
                
                var response = await httpClient.PostAsJsonAsync("Account/Refresh", refreshRequest);

                if (!response.IsSuccessStatusCode)
                    return false;

                var result = await response.Content.ReadFromJsonAsync<AuthResult>();

                if (!result.Success)
                    return false;

                await _localStorage.SetItemAsync("authToken", result.Access_Token);
                await _localStorage.SetItemAsync("refreshToken", result.Refresh_Token);

                ((CustomAuthStateProvider)_authStateProvider)
                    .NotifyUserAuthentication(result.Access_Token);

                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
