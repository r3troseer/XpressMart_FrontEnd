using XpressMart_FrontEnd.Models.Filter;
using XpressMart_FrontEnd.Models.Response.BrandResponse;
using XpressMart_FrontEnd.Models.Response.ProductResponse;

namespace XpressMart_FrontEnd.Services.FilterService
{
	public class FilterService : IFilterService
	{
		private List<BrandResponseModel> AvailableBrands { get; set; } = new List<BrandResponseModel>();
		private ProductFilter filter = new ProductFilter();

		public List<BrandResponseModel> CalculateAvailableBrands(ProductListResponseModel products)
		{
			AvailableBrands = products.Products
				.Where(p => p.Brand != null)
				.GroupBy(p => new { p.Brand.Id, p.Brand.Name })
				.Select(g => new BrandResponseModel
				{
					Id = g.Key.Id,
					Name = g.Key.Name,
					ProductCount = g.Count()
				})
				.ToList();

			return AvailableBrands;
		}

		public void ToggleBrandSelection(string brandId, bool isSelected)
		{
			if (isSelected)
			{
				if (!filter.BrandIds.Contains(brandId))
				{
					filter.BrandIds.Add(brandId);
				}
			}
			else
			{
				filter.BrandIds.Remove(brandId);
			}
		}

		public string BuildQueryString(ProductFilter filter)
		{
			var queryParams = new List<string>();

			if (filter.CategoryId.HasValue)
				queryParams.Add($"CategoryId={filter.CategoryId.Value}");

			if (!string.IsNullOrEmpty(filter.Name))
				queryParams.Add($"Name={Uri.EscapeDataString(filter.Name)}");

			if (filter.MinPrice.HasValue)
				queryParams.Add($"MinPrice={filter.MinPrice.Value}");

			if (filter.MaxPrice.HasValue)
				queryParams.Add($"MaxPrice={filter.MaxPrice.Value}");

			if (filter.BrandIds != null && filter.BrandIds.Any())
				queryParams.AddRange(filter.BrandIds.Select(brandId => $"BrandIds={Uri.EscapeDataString(brandId)}"));

			if (filter.StartDate.HasValue)
				queryParams.Add($"StartDate={filter.StartDate.Value:yyyy-MM-dd}");

			if (filter.EndDate.HasValue)
				queryParams.Add($"EndDate={filter.EndDate.Value:yyyy-MM-dd}");

			if (filter.Limit.HasValue)
				queryParams.Add($"Limit={filter.Limit.Value}");

			return queryParams.Any() ? "?" + string.Join("&", queryParams) : string.Empty;
		}
	}
}
