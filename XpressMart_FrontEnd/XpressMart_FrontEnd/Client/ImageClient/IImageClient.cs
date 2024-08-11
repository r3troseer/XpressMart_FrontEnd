using XpressMart_FrontEnd.Models.Response;
using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Client.ImageClient
{
	public interface IImageClient
	{
		Task<BaseResponse<MainImageResponseModel>> GetImage(string id);
	}
}
