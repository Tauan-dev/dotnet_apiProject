public class User  {
    public int? userId { get; set; }
    public string? name { get; set; }
    public string? birthdate{ get; set; }
    public string? email { get; set; }

    // relations one to many

    public ICollection<Contact>? Contatcs {get; set; }
    
    public ICollection<Order>?  Orders {get;set;}
}