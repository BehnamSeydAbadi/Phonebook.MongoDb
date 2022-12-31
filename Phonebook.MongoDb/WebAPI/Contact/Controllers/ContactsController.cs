using WebAPI.Common.Controllers;
using Microsoft.AspNetCore.Mvc;
using Business.Contact.Dtos;
using Business.Contact;

namespace WebAPI.Contact.Controllers
{
    public class ContactsController : BaseApiController
    {
        private readonly IContactBusiness _contactBusiness;

        public ContactsController(IContactBusiness contactBusiness)
        {
            _contactBusiness = contactBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Post(ContactDto dto)
        {
            var contactId = await _contactBusiness.InsertAsync(dto);

            return Ok(contactId);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var contact = await _contactBusiness.GetAsync(id);

            return Ok(contact);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _contactBusiness.DeleteAsync(id);

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ContactDto dto)
        {
            await _contactBusiness.UpdateAsync(id, dto);

            return Ok();
        }
    }
}
