namespace XpressMart_FrontEnd.Models.Response.BrandResponse
{
	public class BrandResponseModel : BaseIdResponse<string>
	{
		public string Name { get; set; }
		public int ProductCount { get; set; }
		public string ThumbnailUrl { get; set; }
	}
}
