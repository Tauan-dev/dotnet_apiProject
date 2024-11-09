using ApiProduct.Models;

namespace ApiProduct.Dto.Contact
{
    public class ContactDTO
    {
        public int ContactId { get; set; }
        public string? Type { get; set; }
        public string? Number { get; set; }
        public int? IdUser { get; set; }
    }
}
