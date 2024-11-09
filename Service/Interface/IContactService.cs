using ApiProduct.Dto.Contact;
namespace ApiProduct.Service.Interface
{
    public interface IContactService
{
    Task<IEnumerable<ContactDTO>> GetAllContactsAsync();
    Task<ContactDTO> GetContactByIdAsync(int contactId);
    Task<ContactDTO> CreateContactAsync(CreateContactDTO contact);
    Task<bool> UpdateContactAsync(int contactId, UpdateContactDTO contact);
    Task<bool> DeleteContactAsync(int contactId);
}
}
