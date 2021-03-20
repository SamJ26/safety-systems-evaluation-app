using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SSEA.Client.WASM.Authentication
{
    public class AuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService storageService;
        private readonly HttpClient httpClient;
        private readonly AuthenticationState anonymous;

        public AuthStateProvider(ILocalStorageService storageService, HttpClient httpClient)
        {
            this.storageService = storageService;
            this.httpClient = httpClient;
            anonymous = new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var token = await storageService.GetItemAsync<string>("AuthToken");
            if (string.IsNullOrWhiteSpace(token))
                return anonymous;

            httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
            return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwtAuthType")));
        }

        public void NotifyUserAuthentication(string email)
        {
            var claims = new Claim[]
            {
                new Claim(ClaimTypes.Name, email)
            };
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(claims, "jwtAuthType"));
            var authenticationState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authenticationState);
        }

        public void NotifyUserLogout()
        {
            var authenticationState = Task.FromResult(anonymous);
            NotifyAuthenticationStateChanged(authenticationState);
        }
    }
}
