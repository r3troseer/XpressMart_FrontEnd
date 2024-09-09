using XpressMart_FrontEnd.Models.Request.CloudinaryRequest;

namespace XpressMart_FrontEnd.Models.Request.BrandRequest
{
    public class BrandRequestModel
    {
        public string Name { get; set; }
        public CloudinaryRequestModel Thumbnail { get; set; }
    }
}
