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
            var contactId = await _contactBusiness.InsertAsync(dto);

            return Ok(new OutputViewModel { Data = contactId });
        }
    }
}
