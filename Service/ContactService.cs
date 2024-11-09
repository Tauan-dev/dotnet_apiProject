using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiProduct.Data; // Certifique-se de que ApplicationDbContext está neste namespace
using ApiProduct.Service.Interface; // Interface IContactService
using ApiProduct.Dto.Contact;
using ApiProduct.Models;

namespace ApiProduct.Service
{
    public class ContactService : IContactService
    {
        private readonly ApplicationDbContext _dbContext;

        public ContactService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<ContactDTO>> GetAllContactsAsync()
        {
            return await _dbContext.Contacts
                .Select(contact => new ContactDTO
                {
                    ContactId = contact.ContactId ?? 0,
                    Type = contact.Type,
                    Number = contact.Number,
                    IdUser = contact.IdUser ?? 0
                })
                .ToListAsync();
        }

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
                IdUser = contact.IdUser ?? 0
            };
        }

        public async Task<ContactDTO> CreateContactAsync(CreateContactDTO contactDto)
        {
            var contact = new Contact
            {
                Type = contactDto.Type,
                Number = contactDto.Number,
                IdUser = contactDto.IdUser
            };

            _dbContext.Contacts.Add(contact);
            await _dbContext.SaveChangesAsync();

            return new ContactDTO
            {
                ContactId = contact.ContactId ?? 0,
                Type = contact.Type,
                Number = contact.Number,
                IdUser = contact.IdUser ?? 0
            };
        }

        public async Task<bool> UpdateContactAsync(int contactId, UpdateContactDTO contactDto)
        {
            var contact = await _dbContext.Contacts.FindAsync(contactId);
            if (contact == null)
            {
                throw new KeyNotFoundException("Contato não encontrado");
            }

            contact.Type = contactDto.Type;
            contact.Number = contactDto.Number;

            _dbContext.Entry(contact).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteContactAsync(int contactId)
        {
            var contact = await _dbContext.Contacts.FindAsync(contactId);
            if (contact == null)
            {
                throw new KeyNotFoundException("Contato não encontrado");
            }

            _dbContext.Contacts.Remove(contact);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
