using XpressMart_FrontEnd.Models.Enums;

namespace XpressMart_FrontEnd.Models.Request.PaymentRequest
{
    public class PaymentRequestModel
    {
        public string OrderId { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
