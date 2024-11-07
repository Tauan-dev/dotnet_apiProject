public class Order {
    public int orderId { get; set; }
    public string status { get; set; }
    public int quantity { get; set; }

    // relations many to one 
    public int idUSer {get;set;}
    public User User { get; set;}

    //relations many to many 

    public ICollection<Product> Products { get; set;}
}