using XpressMart_FrontEnd.Models.Entities;

namespace XpressMart_FrontEnd.Models.Response.ProductResponse
{
    public class ProductDetailResponseModel : ProductResponseModel
    {
        public string Description { get; set; }
        public virtual ICollection<ProductImage> Images { get; set; }
    }
}
