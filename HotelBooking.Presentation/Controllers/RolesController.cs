using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
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

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdRole = _service.RoleService.CreateRole(role);
        return CreatedAtRoute("RoleById", new { id = createdRole.Id }, createdRole);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateRole(Guid id, [FromBody] RoleForUpdateDto role)
    {
        if (role is null)
            return BadRequest("RoleForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        _service.RoleService.UpdateRole(id, role, trackChanges: true);
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateRole(
        Guid id,
        [FromBody] JsonPatchDocument<RoleForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roleToPatch, roleEntity) = _service.RoleService.GetRoleForPatch(id, trackChanges: true);
        patchDoc.ApplyTo(roleToPatch);

        _service.RoleService.SaveChangesForPatch(roleToPatch, roleEntity);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRole(Guid id)
    {
        _service.RoleService.DeleteRole(id, trackChanges: false);
        return NoContent();
    }
}