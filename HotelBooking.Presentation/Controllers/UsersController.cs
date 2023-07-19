using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace HotelBooking.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IServiceManager _service;
    public UsersController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetUsers()
    {
        var users = _service.UserService.GetAllUsers(trackChanges: false);
        return Ok(users);
    }

    [HttpGet("{id:guid}", Name = "UserById")]
    public IActionResult GetUser(Guid id)
    {
        var user = _service.UserService.GetUser(id, trackChanges: false);
        return Ok(user);
    }

    [HttpPost]
    public IActionResult CreateUser([FromBody] UserForCreationDto user)
    {
        if (user is null)
            return BadRequest("UserForCreationDto object is null");
        var createdUser = _service.UserService.CreateUser(user);
        return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateUser(Guid id, [FromBody] UserForUpdateDto user)
    {
        if (user is null)
            return BadRequest("UserForUpdateDto object is null");
        _service.UserService.UpdateUser(id, user, trackChanges: true);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteUser(Guid id)
    {
        _service.UserService.DeleteUser(id, trackChanges: false);
        return NoContent();
    }
}