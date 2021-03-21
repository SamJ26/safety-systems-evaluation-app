using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SSEA.Client.BL.Services;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SSEA.Client.WASM.Authentication
{
    public class AuthenticationService
    {
        private readonly ILocalStorageService storageService;
        private readonly HttpClient httpClient;
        private readonly AuthenticationStateProvider authStateProvider;
        private readonly IClientService clientService;

        public AuthenticationService(ILocalStorageService storageService, HttpClient httpClient, AuthenticationStateProvider authStateProvider, IClientService clientService)
        {
            this.storageService = storageService;
            this.httpClient = httpClient;
            this.authStateProvider = authStateProvider;
            this.clientService = clientService;
        }

        public async Task<AuthResponseModel> RegisterUserAsync(RegisterUserModel model)
        {
            var result = await clientService.RegisterUserAsync(model);
            return result;
        }

        public async Task<AuthResponseModel> LoginUserAsync(LoginUserModel model)
        {
            var result = await clientService.LoginUserAsync(model);

            // Login failed -> return result and show error messages
            if (result.IsSuccess == false)
                return result;

            // Login successful -> set token in local storage and set default request header
            await storageService.SetItemAsync("AuthToken", result.Token);
            ((AuthStateProvider)authStateProvider).NotifyUserAuthentication(result.Token);
            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", result.Token);
            return result;
        }

        public async Task LogoutUserAsync()
        {
            await storageService.RemoveItemAsync("AuthToken");
            ((AuthStateProvider)authStateProvider).NotifyUserLogout();
            httpClient.DefaultRequestHeaders.Authorization = null;
        }
    }
}
