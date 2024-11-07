public class Product {
    public int idProduct { get; set; }
    public string name { get; set; }
    public string type { get; set; }
    public decimal price { get; set; }


    //relations many to many 

    public Icollection<Order> Orders { get; set;}
}