using XpressMart_FrontEnd.Models.Response.BrandResponse;

namespace XpressMart_FrontEnd.Models.Response.ProductResponse
{
	public class ProductResponseModel : BaseIdResponse<string>
	{
		public string Name { get; set; }
		public decimal Price { get; set; }
		public int quantity { get; set; }
		public int CategoryId { get; set; }
		public BrandResponseModel? Brand { get; set; }
		public MainImageResponseModel? MainImageDetail { get; set; }
		public string? MainImageFileId { get; set; }
		public string? MainImageUrl { get; set; }
	}
}
