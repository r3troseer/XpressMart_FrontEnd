using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Models.Response.CategoryResponse
{
	public class CategoryDetailResponseModel : CategoryResponseModel
	{
		public ICollection<ProductResponseModel> Products { get; set; }
	}
}
