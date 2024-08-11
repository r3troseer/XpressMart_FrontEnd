namespace XpressMart_FrontEnd.Models.Request.ProductImageRequest
{
    public class ProductImageRequestModel
    {
        public string fileDataString { get; set; }
        public string contentType { get; set; }
        public string FileName { get; set; }
        public Dictionary<string, string>? FileInfo { get; set; }
    }
}
