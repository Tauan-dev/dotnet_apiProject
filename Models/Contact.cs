public class Contact {
    public int contactid {get;set;},
    public string type {get;set;},
    public string number  {get;set;},

    //many to many

    public ICollection<User> Users {get; set;}
}