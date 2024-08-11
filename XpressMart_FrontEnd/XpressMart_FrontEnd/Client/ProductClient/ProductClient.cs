using XpressMart_FrontEnd.Models.Response;
using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Client.ProductClient
{
	public class ProductClient : IProductClient
	{
		private readonly HttpClient _httpClient;

		public ProductClient(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		public async Task<BaseResponse<ProductListResponseModel>> GetFilteredProductsAsync(string queryString)
			=> await _httpClient.GetFromJsonAsync<BaseResponse<ProductListResponseModel>>($"api/Products/filter{queryString}");
	}
}
