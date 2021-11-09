using Domain.Interfaces.Handlers;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public abstract class CustomControllerBase : ControllerBase
    {
        protected IActionResult GetResponse(object response, IHandler handler)
        {
            if (handler.IsValid)
                return Ok(response);

            return BadRequest(handler.Notifications);
        }

        protected IActionResult GetResponse(IHandler handler)
        {
            if (handler.IsValid)
                return Ok();

            return BadRequest(handler.Notifications);
        }
    }
}
