using Entities.ErrorModel;
using Entities.Models;
using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.AuthenticationDtos;
namespace HotelBooking.Presentation.Controllers.Authentication;

[ApiController]
[Route("api/user")]
[Consumes("application/json")]
[Produces("application/json")]
public class UserController : ControllerBase
{
    private readonly IServiceManager _service;
    public UserController(IServiceManager service) => _service = service;

    [HttpPut]
    [ProducesResponseType(typeof(IdentityUser), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 401)]
    public async Task<IActionResult> UpdateUser([FromBody] UserDto user)
    {
        var updatedUser = await _service.AuthenticationService.UpdateUser(user);
        return Ok(updatedUser);
    }
}
