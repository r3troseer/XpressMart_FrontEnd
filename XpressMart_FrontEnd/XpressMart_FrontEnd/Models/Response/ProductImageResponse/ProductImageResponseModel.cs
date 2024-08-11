using XpressMart_FrontEnd.Models.Response;

namespace XpressMart_FrontEnd.Models.Response.ProductImageResponse
{
    public class ProductImageResponseModel : BaseIdResponse<string>
    {
        public string ProductId { get; set; }
        public string BackblazeFileId { get; set; }
        public string FileName { get; set; }
    }
}
