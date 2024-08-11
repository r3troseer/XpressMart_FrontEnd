using System.ComponentModel.DataAnnotations.Schema;

namespace XpressMart_FrontEnd.Models.Entities
{
    public class OrderItem : BaseEntity<string>
    {

        public string? OrderId { get; set; }
        public virtual Order? Order { get; set; }
        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
