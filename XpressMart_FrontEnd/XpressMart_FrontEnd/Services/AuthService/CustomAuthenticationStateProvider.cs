using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace XpressMart_FrontEnd.Services.AuthService
{
	public class CustomAuthenticationStateProvider : AuthenticationStateProvider
	{
		private readonly ILocalStorageService _localStorageService;
		private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

		public CustomAuthenticationStateProvider(ILocalStorageService localStorageService)
		{
			_localStorageService = localStorageService;
		}

		public override async Task<AuthenticationState> GetAuthenticationStateAsync()
		{
			var token = await _localStorageService.GetItemAsync<string>("token");
			if (string.IsNullOrEmpty(token))
			{
				return new AuthenticationState(_anonymous);
			}

			var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
			var user = new ClaimsPrincipal(identity);
			return await Task.FromResult(new AuthenticationState(user));
		}

		public void AuthenticateUser(string token)
		{
			var identity = new ClaimsIdentity(JwtParser.ParseClaimsFromJwt(token), "jwt");
			var user = new ClaimsPrincipal(identity);
			var state = new AuthenticationState(user);

			_localStorageService.SetItemAsync("token", token);

			NotifyAuthenticationStateChanged(Task.FromResult(state));
		}

		public async Task LogoutAsync()
		{
			await _localStorageService.RemoveItemAsync("token");

			NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(_anonymous)));
		}
	}
}
