using XpressMart_FrontEnd.Models.Response;
using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Client.ProductClient
{
	public interface IProductClient
	{
		Task<BaseResponse<ProductListResponseModel>> GetFilteredProductsAsync(string queryString);
	}
}
