using XpressMart_FrontEnd.Models.Request;
using XpressMart_FrontEnd.Models.Request.OrderItemRequest;

namespace XpressMart_FrontEnd.Models.Request.OrderRequest
{
    public class OrderUpdateRequestModel : BaseRequest<string>
    {
        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual ICollection<OrderItemRequestModel> OrderItems { get; set; }
    }
}
