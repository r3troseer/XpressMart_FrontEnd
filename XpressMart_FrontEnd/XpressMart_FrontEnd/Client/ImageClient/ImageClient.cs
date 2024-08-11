using XpressMart_FrontEnd.Models.Response;
using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Client.ImageClient
{
	public class ImageClient : IImageClient
	{
		private readonly HttpClient _httpClient;

		public ImageClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<BaseResponse<MainImageResponseModel>> GetImage(string id)
		{
			var response = await _httpClient.GetFromJsonAsync<BaseResponse<MainImageResponseModel>>($"api/Products/image/{id}");
			return response;
		}

		//public async Task<BaseResponse<string>> GetImageAsBase64StringAsync(string id)
		//{
		//    var response = await _httpClient.GetFromJsonAsync<BaseResponse<MainImageResponseModel>>($"api/Products/image/{id}");
		//    if (response?.Data?.FileString != null)
		//    {
		//        string base64String = response.Data.FileString;
		//        return new BaseResponse<string> { Data = base64String };
		//    }
		//    return new BaseResponse<string> { Data = null };
		//}
	}
}
