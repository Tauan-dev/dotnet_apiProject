using Microsoft.EntityFrameworkCore;


namespace ApiProduct.Data {
public class ApplicationDbContext : DbContext {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) {
    }
    public DbSet<Product> Products {get; set;}
    public DbSet<Order> Orders {get; set;}
    public DbSet<Contact> Contacts {get; set;}
    public DbSet<User> Users {get; set;}
}
}
