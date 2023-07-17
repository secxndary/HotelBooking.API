using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
namespace HotelBooking.Presentation.Controllers;

[Route("api/roles")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IServiceManager _service;
    public RolesController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetRoles()
    {
        var roles = _service.RoleService.GetAllRoles(trackChanges: false);
        return Ok(roles);
    }

    [HttpGet("{id:guid}", Name = "RoleById")]
    public IActionResult GetRole(Guid id)
    {
        var role = _service.RoleService.GetRole(id, trackChanges: false);
        return Ok(role);
    }

    [HttpPost]
    public IActionResult CreateRole([FromBody] RoleForCreationDto role)
    {
        if (role is null)
            return BadRequest("RoleForCreationDto object is null");
        var createdRole = _service.RoleService.CreateRole(role);
        return CreatedAtRoute("RoleById", new { id = createdRole.Id }, createdRole);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRole(Guid id)
    {
        _service.RoleService.DeleteRole(id, trackChanges: false);
        return NoContent();
    }
}