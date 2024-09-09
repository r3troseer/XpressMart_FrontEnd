using XpressMart_FrontEnd.Models.Request.ProductRequest;
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


        public async Task<BaseResponse> CreateProductAsync(ProductRequestModel request)
        {
            var response = await _httpClient.PostAsMultipartAsync("api/Products", request);

            response.EnsureSuccessStatusCode();

            return await response.Content.ReadFromJsonAsync<BaseResponse>();
        }
    }
}
