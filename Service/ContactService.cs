using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Data;

public class ContactService : IContactService
{
    private readonly ApplicationDbContext _dbContext;

    public ContactService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    // Método para obter todos os contatos e retornar como ContactDTO
    public async Task<IEnumerable<ContactDTO>> GetAllContactsAsync()
    {
        return await _dbContext.Contacts
            .Select(contact => new ContactDTO
            {
                ContactId = contact.ContactId ?? 0,
                Type = contact.Type,
                Number = contact.Number,
                UserId = contact.IdUser ?? 0
            })
            .ToListAsync();
    }

    // Método para obter um contato específico pelo ID e retornar como ContactDTO
    public async Task<ContactDTO> GetContactByIdAsync(int contactId)
    {
        var contact = await _dbContext.Contacts.FindAsync(contactId);
        if (contact == null)
        {
            throw new KeyNotFoundException("Contato não encontrado");
        }

        return new ContactDTO
        {
            ContactId = contact.ContactId ?? 0,
            Type = contact.Type,
            Number = contact.Number,
            UserId = contact.IdUser ?? 0
        };
    }

    // Método para criar um novo contato usando CreateContactDTO
    public async Task<ContactDTO> CreateContactAsync(CreateContactDTO createContactDto)
    {
        var contact = new Contact
        {
            Type = createContactDto.Type,
            Number = createContactDto.Number,
            IdUser = createContactDto.UserId
        };

        _dbContext.Contacts.Add(contact);
        await _dbContext.SaveChangesAsync();

        return new ContactDTO
        {
            ContactId = contact.ContactId ?? 0,
            Type = contact.Type,
            Number = contact.Number,
            UserId = contact.IdUser ?? 0
        };
    }

    // Método para atualizar um contato usando UpdateContactDTO
    public async Task<bool> UpdateContactAsync(int contactId, UpdateContactDTO updateContactDto)
    {
        var existingContact = await _dbContext.Contacts.FindAsync(contactId);
        if (existingContact == null)
        {
            return false;
        }

        existingContact.Type = updateContactDto.Type;
        existingContact.Number = updateContactDto.Number;
        existingContact.IdUser = updateContactDto.UserId;

        _dbContext.Entry(existingContact).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return true;
    }

    // Método para deletar um contato
    public async Task<bool> DeleteContactAsync(int contactId)
    {
        var contact = await _dbContext.Contacts.FindAsync(contactId);
        if (contact == null)
        {
            throw new KeyNotFoundException("Contato não cadastrado");
        }

        _dbContext.Contacts.Remove(contact);
        await _dbContext.SaveChangesAsync();
        return true;
    }
}
