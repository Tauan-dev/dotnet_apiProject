namespace ApiProduct.Models
{
    public class Order
    {
        public int? OrderId { get; set; }
        public string? Status { get; set; }
        public int? Quantity { get; set; }

        // Relacionamento Many-to-One com User
        public int? IdUser { get; set; }
        public User? User { get; set; }

        // Relacionamento Many-to-Many com Product
        public ICollection<Product>? Products { get; set; } 
    }
}
