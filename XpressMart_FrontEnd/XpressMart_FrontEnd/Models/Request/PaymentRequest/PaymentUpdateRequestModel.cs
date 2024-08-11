using XpressMart_FrontEnd.Models.Enums;

namespace XpressMart_FrontEnd.Models.Request.PaymentRequest
{
    public class PaymentUpdateRequestModel : BaseRequest<string>
    {
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
    }
}
