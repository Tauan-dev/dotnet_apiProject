public class User  {
    public int id { get; set; },
    public string name { get; set; },
    public string birthdate{ get; set; },
    public string email { get; set; },

    // relations many to many

    public ICollection<Contact> Contatcs {get; set; }
    
}