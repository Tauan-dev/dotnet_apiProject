public class Product {
    public int? productId { get; set; }
    public string? name { get; set; }
    public string? type { get; set; }
    public decimal? price { get; set; }


    //relations many to many 

    public ICollection<Order>? Orders { get; set;}
}