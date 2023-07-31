using System.Text.Json;
using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

[Route("api/users")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IServiceManager _service;
    public UsersController(IServiceManager service) => _service = service;


    [HttpGet(Name = "GetUsers")]
    [HttpHead]
    public async Task<IActionResult> GetUsers([FromQuery] UserParameters userParameters)
    {
        var (users, metaData) = await _service.UserService.GetAllUsersAsync(userParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(users);
    }

    [HttpGet("{id:guid}", Name = "UserById")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        var user = await _service.UserService.GetUserAsync(id);
        return Ok(user);
    }

    [HttpPost(Name = "CreateUser")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateUser([FromBody] UserForCreationDto user)
    {
        var createdUser = await _service.UserService.CreateUserAsync(user);
        return CreatedAtRoute("UserById", new { id = createdUser.Id }, createdUser);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateUser(Guid id, [FromBody] UserForUpdateDto user)
    {
        var updatedUser = await _service.UserService.UpdateUserAsync(id, user);
        return Ok(updatedUser);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateUser(Guid id, 
        [FromBody] JsonPatchDocument<UserForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (userToPatch, userEntity) = await _service.UserService.GetUserForPatchAsync(id);
        patchDoc.ApplyTo(userToPatch);

        TryValidateModel(userToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedUser = await _service.UserService.SaveChangesForPatchAsync(userToPatch, userEntity);
        return Ok(updatedUser);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteUser(Guid id)
    {
        await _service.UserService.DeleteUserAsync(id);
        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetUsersOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}