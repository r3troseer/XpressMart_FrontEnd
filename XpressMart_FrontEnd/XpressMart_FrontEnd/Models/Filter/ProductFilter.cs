namespace XpressMart_FrontEnd.Models.Filter
{
	public class ProductFilter
	{
		public string? Name { get; set; }
		public int? CategoryId { get; set; }
		public decimal? MinPrice { get; set; }
		public decimal? MaxPrice { get; set; }
		public List<string>? BrandIds { get; set; }
		public DateTime? StartDate { get; set; }
		public DateTime? EndDate { get; set; }
		public int? Limit { get; set; }
	}
}
