using XpressMart_FrontEnd.Models.Entities;

namespace XpressMart_FrontEnd.Models.Response.OrderResponse
{
    public class OrderResponseModel
    {
        public string CustomerId { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal TotalAmount { get; set; }

        public virtual Payment Payment { get; set; }

        public virtual ICollection<OrderItem> OrderItems { get; set; }
    }
}
