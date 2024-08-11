using System.ComponentModel.DataAnnotations.Schema;
using XpressMart_FrontEnd.Models.Enums;

namespace XpressMart_FrontEnd.Models.Entities
{
    public class Payment : BaseEntity<string>
    {
        public string OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual Order Order { get; set; }
        public decimal Amount { get; set; }
        public string PaymentMethod { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public DateTime PaymentDate { get; set; }
    }
}
