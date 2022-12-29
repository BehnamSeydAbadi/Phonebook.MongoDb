using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Common.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class BaseApiController : ControllerBase
    {
    }
}
