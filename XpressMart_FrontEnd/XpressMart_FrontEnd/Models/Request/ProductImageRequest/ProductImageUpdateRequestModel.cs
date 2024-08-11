using XpressMart_FrontEnd.Models.Request;

namespace XpressMart_FrontEnd.Models.Request.ProductImageRequest
{
    public class ProductImageUpdateRequestModel : BaseRequest<string>
    {
        public string BackblazeFileId { get; set; }
        public string FileName { get; set; }
    }
}
