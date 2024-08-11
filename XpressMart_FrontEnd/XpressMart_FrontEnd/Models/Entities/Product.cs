namespace XpressMart_FrontEnd.Models.Entities
{
    public class Product : BaseEntity<string>
    {

        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int quantity { get; set; }
        public int CategoryId { get; set; }
        public string MainImageFileId { get; set; }
        public virtual Category Category { get; set; }
        public virtual ICollection<ProductImage>? Images { get; set; }
    }
}
