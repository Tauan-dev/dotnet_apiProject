using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiProduct.Service.Interface;
using ApiProduct.Dto.Contact;


[Route("api/[controller]")]
[ApiController]
public class ContactController : ControllerBase
{
    private readonly IContactService _contactService;

    public ContactController(IContactService contactService)
    {
        _contactService = contactService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactDTO>>> GetAllContacts()
    {
        return Ok(await _contactService.GetAllContactsAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ContactDTO>> GetContactById(int id)
    {
        var contact = await _contactService.GetContactByIdAsync(id);
        return contact != null ? Ok(contact) : NotFound("Contato não encontrado");
    }

    [HttpPost]
    public async Task<ActionResult<ContactDTO>> CreateContact(CreateContactDTO createContactDto)
    {
        var contact = await _contactService.CreateContactAsync(createContactDto);
        return CreatedAtAction(nameof(GetContactById), new { id = contact.ContactId }, contact);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContact(int id, UpdateContactDTO updateContactDto)
    {
        if (await _contactService.UpdateContactAsync(id, updateContactDto))
            return NoContent();
        return NotFound("Contato não encontrado");
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContact(int id)
    {
        if (await _contactService.DeleteContactAsync(id))
            return NoContent();
        return NotFound("Contato não encontrado");
    }
}
