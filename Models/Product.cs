namespace ApiProduct.Models
{
    public class Product
    {
        public int? ProductId { get; set; }
        public string? Name { get; set; }
        public string? Type { get; set; }
        public decimal? Price { get; set; }

        // Relacionamento Many-to-Many com Order
        public ICollection<Order>? Orders { get; set; } 
    }
}
