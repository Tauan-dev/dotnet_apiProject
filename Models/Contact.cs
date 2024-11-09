namespace ApiProduct.Models
{
   public class Contact
   {
       public int? ContactId { get; set; }
       public string? Type { get; set; }
       public string? Number { get; set; }

       // Relacionamento Many-to-One
       public int? IdUser { get; set; }
       public User? User { get; set; }
   }
}
