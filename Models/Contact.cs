public class Contact {
    public int? contactId {get;set;}
    public string? type {get;set;}
    public string? number  {get;set;}

    //many to one
    public int? idUser {get;set;}
    public User? User {get;set;}
}