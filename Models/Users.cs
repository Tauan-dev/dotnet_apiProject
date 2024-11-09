namespace ApiProduct.Models
{
    public class User
    {
        public int? UserId { get; set; }
        public string? Name { get; set; }
        public string? Birthdate { get; set; }
        public string? Email { get; set; }

        // Relacionamentos One-to-Many
        public ICollection<Contact> Contacts { get; set; } = new List<Contact>();
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
