using XpressMart_FrontEnd.Models.Request;

namespace XpressMart_FrontEnd.Models.Request.OrderItemRequest
{
    public class OrderItemUpdateRequestModel : BaseRequest<string>
    {
        public string OrderId { get; set; }
        public int? Quantity { get; set; }
    }
}
