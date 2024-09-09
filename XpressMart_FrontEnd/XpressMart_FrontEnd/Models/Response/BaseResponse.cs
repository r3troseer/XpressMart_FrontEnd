using XpressMart.Core.Models.Response.XpressMart.Core.Models.Response;

namespace XpressMart_FrontEnd.Models.Response
{
    public class BaseResponse
    {
        public bool isSuccess { get; set; }
        public bool isFailure { get; set; }
        public Error Error { get; set; }
    }

    public class BaseResponse<T>
    {
        public bool isSuccess { get; set; }
        public bool isFailure { get; set; }
        public Error Error { get; set; }
        public T Data { get; set; }
    }
}