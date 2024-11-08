namespace ApiProduct.Service.Interface{
public interface IContactService {
    Task <IEnumerable<Contact>> GetAllContactsAsync();
    Task<Contact> GetContactByIsAsync(int contactId);
    Task<Contact> CreateContactAsync( Contact contact );
    Task<bool> UpdateContactAsync(int contactId, Contact contact);
    Task<bool> DeleteContactAsync(int contactId);
}
}

