using ApiProduct.Dto.Contact;
using ApiProduct.Dto.Order;

namespace ApiProduct.Dto.User
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string? Name { get; set; }
        public string? Birthdate { get; set; }
        public string? Email { get; set; }
        public List<ContactDTO>? Contacts { get; set; } // IDs dos contatos associados
        public List<OrderDTO>? Orders { get; set; }
    }

}
