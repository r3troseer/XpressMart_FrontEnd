using XpressMart_FrontEnd.Models.Enums;

namespace XpressMart_FrontEnd.Models.Request.DeliveryRequest
{
    public class DeliveryRequestModel
    {
        public string OrderId { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public virtual DeliveryStatus DeliveryStatus { get; set; }
    }
}
