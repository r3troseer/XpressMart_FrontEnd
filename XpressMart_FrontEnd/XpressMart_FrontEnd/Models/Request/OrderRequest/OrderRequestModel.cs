using XpressMart_FrontEnd.Models.Request.OrderItemRequest;

namespace XpressMart_FrontEnd.Models.Request.OrderRequest
{
    public class OrderRequestModel
    {
        public string CustomerId { get; set; }

        public decimal TotalAmount { get; set; }

        public DateTime OrderDate { get; set; } = DateTime.Now;

        public virtual ICollection<OrderItemRequestModel> OrderedItems { get; set; }
    }
}
