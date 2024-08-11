namespace XpressMart_FrontEnd.Models.Response.ProductResponse
{
	public class ProductListResponseModel
	{
		public decimal MaxPrice { get; set; }
		public decimal MinPrice { get; set; }
		public List<ProductResponseModel> Products { get; set; }
	}
}
