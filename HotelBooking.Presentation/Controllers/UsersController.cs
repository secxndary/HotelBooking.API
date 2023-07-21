using Microsoft.AspNetCore.JsonPatch;
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
    public async Task<IActionResult> GetUsers()
    {
        var users = await _service.UserService.GetAllUsersAsync(trackChanges: false);
        return Ok(users);
    }

    [HttpGet("{id:guid}", Name = "UserById")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _service.UserService.GetUserAsync(id, trackChanges: false);
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto user)
    {
        if (user is null)
            return BadRequest("UserForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdUser = await _service.UserService.CreateUserAsync(user);
        return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForUpdateDto user)
    {
        if (user is null)
            return BadRequest("UserForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.UserService.UpdateUserAsync(id, user, trackChanges: true);
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateUser(
        Guid id, 
        [FromBody] JsonPatchDocument<UserForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (userToPatch, userEntity) = await _service.UserService.GetUserForPatchAsync(id, trackChanges: true);
        patchDoc.ApplyTo(userToPatch);

        TryValidateModel(userToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.UserService.SaveChangesForPatchAsync(userToPatch, userEntity);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _service.UserService.DeleteUserAsync(id, trackChanges: false);
        return NoContent();
    }
}