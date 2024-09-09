using XpressMart_FrontEnd.Models.Auth;

namespace XpressMart_FrontEnd.Client.AuthClient
{
	public class AuthClient : IAuthClient
	{
		private readonly HttpClient _httpClient;

		public AuthClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<UserManagerResponse> LoginAsync(LoginModel model)
		{
			var response = await _httpClient.PostAsJsonAsync("api/Auth/Login", model);

			return await response.Content.ReadFromJsonAsync<UserManagerResponse>();
		}

		public async Task<UserManagerResponse> RegisterAsync(RegisterModel model)
		{
			var response = await _httpClient.PostAsJsonAsync("api/Auth/Register", model);

			return await response.Content.ReadFromJsonAsync<UserManagerResponse>();
		}
	}
}
