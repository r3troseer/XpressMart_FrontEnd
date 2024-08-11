namespace XpressMart_FrontEnd.Models.Response
{
    public class ImageResponse : BaseIdResponse<string>
    {
        public string FileString { get; set; }
        public string FileName { get; set; }
        //purpose to be reviewed
        public Dictionary<string, string> FileInfo { get; set; }
        public string ContentType { get; set; }
    }
}
