using System.ComponentModel.DataAnnotations.Schema;
using XpressMart_FrontEnd.Models.Entities;

namespace XpressMart_FrontEnd.Models.Response.OrderItemResponse
{
    public class OrderItemResponseModel
    {
        public string? OrderId { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
