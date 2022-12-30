using Business.Contact;
using Business.Contact.Dtos;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.ViewModels;

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
            try
            {
                var contactId = await _contactBusiness.InsertAsync(dto);

                return Ok(new OutputViewModel { Data = contactId });
            }
            catch (Exception ex)
            {
                return BadRequest(new OutputViewModel { Error = ex.Message });
            }

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var contact = await _contactBusiness.GetAsync(id);

            return Ok(new OutputViewModel { Data = contact });
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _contactBusiness.DeleteAsync(id);

            return Ok(new OutputViewModel());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, ContactDto dto)
        {
            await _contactBusiness.UpdateAsync(id, dto);

            return Ok(new OutputViewModel());
        }
    }
}
