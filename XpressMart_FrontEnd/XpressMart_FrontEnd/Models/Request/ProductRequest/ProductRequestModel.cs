using XpressMart_FrontEnd.Models.Request.FileStorageRequest;
using XpressMart_FrontEnd.Models.Request.ProductImageRequest;

namespace XpressMart_FrontEnd.Models.Request.ProductRequest
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int quantity { get; set; }
        public int CategoryId { get; set; }
        public FileStorageRequestModel MainImage { get; set; }
        public virtual ICollection<ProductImageRequestModel>? ProductImages { get; set; }
    }
}
