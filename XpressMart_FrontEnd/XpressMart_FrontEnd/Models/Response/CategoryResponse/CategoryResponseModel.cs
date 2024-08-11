

namespace XpressMart_FrontEnd.Models.Response.CategoryResponse
{
	public class CategoryResponseModel : BaseIdResponse<int>
	{
		public string Name { get; set; }
		public string Description { get; set; }
		public string ThumbnailUrl { get; set; }
	}
}
