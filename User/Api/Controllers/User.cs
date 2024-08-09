using Microsoft.AspNetCore.Mvc;

namespace ModularMono.App.User.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class User : ControllerBase
{
    [HttpGet]
    public IActionResult GetAllItems()
    {
        return Ok("HELLO");
    }
}
