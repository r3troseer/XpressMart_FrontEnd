using XpressMart_FrontEnd.Models.Enums;

namespace XpressMart_FrontEnd.Models.Entities
{
    public class Delivery : BaseEntity<string>
    {
        public string OrderId { get; set; }
        public virtual Order Order { get; set; }
        public string TrackingNumber { get; set; }
        public DateTime ShippedDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public virtual DeliveryStatus DeliveryStatus { get; set; }
    }
}
