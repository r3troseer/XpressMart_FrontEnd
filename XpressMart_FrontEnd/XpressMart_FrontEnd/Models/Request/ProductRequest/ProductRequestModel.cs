using XpressMart_FrontEnd.Models.Request.CloudinaryRequest;
using XpressMart_FrontEnd.Models.Request.FileStorageRequest;

namespace XpressMart_FrontEnd.Models.Request.ProductRequest
{
    public class ProductRequestModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int CategoryId { get; set; }
        public string? BrandId { get; set; }
        public CloudinaryRequestModel MainImageFile { get; set; }
        public FileStorageRequestModel? MainImage { get; set; }
        public virtual ICollection<CloudinaryRequestModel>? ProductImages { get; set; }
    }
}
