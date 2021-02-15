using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using SSEA.Client.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SSEA.Client.WASM
{
    public class AuthStateProviderService : AuthenticationStateProvider
    {
        private readonly ILocalStorageService storageService;

        public AuthStateProviderService(ILocalStorageService storageService)
        {
            this.storageService = storageService;
        }

        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            // There is LocalUserInfo object in local storage of browser
            if (await storageService.ContainKeyAsync("UserInfo"))
            {
                var userInfo = await storageService.GetItemAsync<LocalUserInfo>("UserInfo");

                var claims = new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userInfo.ID.ToString()),
                    new Claim("FirstName", userInfo.FirstName),
                    new Claim("LastName", userInfo.LastName),
                    new Claim("Email", userInfo.Email),
                    new Claim("AccessToken", userInfo.AccessToken),
                };

                var identity = new ClaimsIdentity(claims, "BearerToken");
                var user = new ClaimsPrincipal(identity);
                var state = new AuthenticationState(user);
                NotifyAuthenticationStateChanged(Task.FromResult(state));
                return state;
            }

            // There is not LocalUserInfo object in local storage of browser
            return new AuthenticationState(new ClaimsPrincipal());
        }

        public async Task LogoutAsync()
        {
            // Removing LocalUserInfo object from local storage of browser
            await storageService.RemoveItemAsync("UserInfo");

            // Notifying components with authorization, that authentication state changed
            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(new ClaimsPrincipal())));
        }
    }
}
