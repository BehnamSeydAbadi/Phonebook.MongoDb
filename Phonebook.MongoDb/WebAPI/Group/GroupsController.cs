using Business.Group;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Common.Controllers;
using WebAPI.Group.Dtos;

namespace WebAPI.Group
{
    public class GroupsController : BaseApiController
    {
        private readonly IGroupBusiness _groupBusiness;

        public GroupsController(IGroupBusiness groupBusiness)
        {
            _groupBusiness = groupBusiness;
        }

        [HttpPost]
        public async Task<IActionResult> Post(GroupDto dto)
        {
            var groupId = await _groupBusiness.InsertAsync(dto.Title);

            return Ok(groupId);
        }
    }
}
