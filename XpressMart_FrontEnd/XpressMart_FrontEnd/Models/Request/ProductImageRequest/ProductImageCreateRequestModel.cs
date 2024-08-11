namespace XpressMart_FrontEnd.Models.Request.ProductImageRequest
{
    public class ProductImageCreateRequestModel : ProductImageRequestModel
    {
        public byte[] fileData { get; set; }
        public string ProductId { get; set; }
        public string BackblazeFileId { get; set; }
    }
}
