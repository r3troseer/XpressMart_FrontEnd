using System.ComponentModel.DataAnnotations.Schema;

namespace XpressMart_FrontEnd.Models.Entities
{
    public class ProductImage : BaseEntity<string>
    {

        public string ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }
        public string BackblazeFileId { get; set; }
        public string FileName { get; set; }
    }
}
