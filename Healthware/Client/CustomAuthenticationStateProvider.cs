using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;

namespace Healthware.Client
{
    public class CustomAuthenticationStateProvider: AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorageService;

        public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
        {
            _localStorageService = localStorageService;
        }
        public async override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var state = new AuthenticationState(new ClaimsPrincipal());

            var jwtToken = await _localStorageService.GetItemAsStringAsync("JWT Token");

            if (!string.IsNullOrEmpty(jwtToken))
            {
                var identity = new ClaimsIdentity(new []
                    {
                        new Claim(ClaimTypes.Name, jwtToken)
                    }, "jwt authentication type");
                state = new AuthenticationState(new ClaimsPrincipal(identity));
            }

            NotifyAuthenticationStateChanged(Task.FromResult(state));
            return state;
        }
    }
}
