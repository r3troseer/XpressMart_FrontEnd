namespace XpressMart_FrontEnd.Models.Response.FileStorageResponse
{
    public class FileStorageResponseModel
    {
        public string FileId { get; set; }

        public string FileName { get; set; }

        public string Action { get; set; }

        public long Size { get; set; }

        public string UploadTimestamp { get; set; }

        public byte[] FileData { get; set; }

        public string ContentLength { get; set; }

        public string ContentSHA1 { get; set; }

        public string ContentType { get; set; }

        public Dictionary<string, string> FileInfo { get; set; }

        public DateTime UploadTimestampDate
        {
            get
            {
                if (!string.IsNullOrEmpty(UploadTimestamp))
                {
                    return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(double.Parse(UploadTimestamp));
                }

                return DateTime.Now;
            }
        }
    }
}
