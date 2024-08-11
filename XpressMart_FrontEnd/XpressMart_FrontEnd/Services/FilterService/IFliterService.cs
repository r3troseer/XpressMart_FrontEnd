using XpressMart_FrontEnd.Models.Filter;
using XpressMart_FrontEnd.Models.Response.BrandResponse;
using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Services.FilterService
{
	public interface IFilterService
	{
		List<BrandResponseModel> CalculateAvailableBrands(ProductListResponseModel products);
		void ToggleBrandSelection(string brandId, bool isSelected);
		string BuildQueryString(ProductFilter filter);
	}
}
