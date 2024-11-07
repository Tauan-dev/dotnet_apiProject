using Microsoft.EntityFrameworkCore;

public class ApliccationDbContext : ApliccationDbContext {
    public ApliccationDbContext(DbContextOptions<ApliccationDbContext> options) : base(options) {
    }
    public DbSet<Product> Products {get; set;}
    public DbSet<Order> Orders {get; set;}
    public DbSet<Contact> Contacts {get; set;}
    public DbSet<User> Users {get; set;}
}