using XpressMart_FrontEnd.Models.Enums;
using XpressMart_FrontEnd.Models.Request;

namespace XpressMart_FrontEnd.Models.Request.DeliveryRequest
{
    public class DeliveryUpdateRequestModel : BaseRequest<string>
    {
        public DateTime? DeliveredDate { get; set; }
        public virtual DeliveryStatus DeliveryStatus { get; set; }
    }
}
