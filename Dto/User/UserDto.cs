public class UserDTO
{
    public int UserId { get; set; }
    public string Name { get; set; }
    public string Birthdate { get; set; }
    public string Email { get; set; }
    public List<int> ContactIds { get; set; } // IDs dos contatos associados
    public List<int> OrderIds { get; set; } // IDs dos pedidos associados
}
