using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;
    public UserController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _service.UserService.GetAllUsers(trackChanges: false);
        return Ok(users);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        var user = _service.UserService.GetUser(id, trackChanges: false);
        return Ok(user);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteUser(Guid id)
    {
        _service.UserService.DeleteUser(id, trackChanges: false);
        return NoContent();
    }
}