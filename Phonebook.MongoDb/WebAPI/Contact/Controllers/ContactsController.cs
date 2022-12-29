using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Common.ViewModels;
using WebAPI.Contact.Dtos;

namespace WebAPI.Contact.Controllers
{
    public class ContactsController : BaseApiController
    {
        [HttpPost]
        public async Task<IActionResult> Post(ContactDto dto)
        {
            return Ok(new OutputViewModel { Data = 1 });
        }
    }
}
