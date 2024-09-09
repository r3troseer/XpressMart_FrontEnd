using XpressMart_FrontEnd.Models.Request.BrandRequest;
using XpressMart_FrontEnd.Models.Response;
using XpressMart_FrontEnd.Models.Response.BrandResponse;

namespace XpressMart_FrontEnd.Client.BrandClient
{
	public class BrandClient : IBrandClient
	{
		private readonly HttpClient httpClient;

		public BrandClient(HttpClient httpClient)
		{
			this.httpClient = httpClient;
		}

		public async Task<BaseResponse<List<BrandResponseModel>>> GetBrandsAsync()
			=> await httpClient.GetFromJsonAsync<BaseResponse<List<BrandResponseModel>>>("api/Brand");

		public async Task<BaseResponse<BrandResponseModel>> GetBrandAsync(string brandId)
			=> await httpClient.GetFromJsonAsync<BaseResponse<BrandResponseModel>>($"api/Brand/{brandId}");

		public async Task<BaseResponse> CreateBrandAsync(BrandRequestModel request)
		{
			var response = await httpClient.PostAsMultipartAsync("api/Brand", request);

			return await response.Content.ReadFromJsonAsync<BaseResponse>();
		}
	}
}
