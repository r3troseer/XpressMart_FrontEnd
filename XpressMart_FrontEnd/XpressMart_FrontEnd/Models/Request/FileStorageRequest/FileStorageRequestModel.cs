namespace XpressMart_FrontEnd.Models.Request.FileStorageRequest
{
    public class FileStorageRequestModel
    {
        public string fileDataString { get; set; }
        public byte[]? fileData { get; set; }
        public string fileName { get; set; }
        public string? contentType { get; set; }
        public Dictionary<string, string>? FileInfo { get; set; }
    }
}
