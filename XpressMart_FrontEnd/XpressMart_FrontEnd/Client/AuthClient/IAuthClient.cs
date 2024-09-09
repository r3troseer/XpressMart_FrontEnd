using XpressMart_FrontEnd.Models.Auth;

namespace XpressMart_FrontEnd.Client.AuthClient
{
	public interface IAuthClient
	{
		Task<UserManagerResponse> LoginAsync(LoginModel model);
		Task<UserManagerResponse> RegisterAsync(RegisterModel model);
	}
}
