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
    public async Task<IActionResult> GetRoles()
    {
        var roles = await _service.RoleService.GetAllRolesAsync();
        return Ok(roles);
    }

    [HttpGet("{id:guid}", Name = "RoleById")]
    public async Task<IActionResult> GetRole(Guid id)
    {
        var role = await _service.RoleService.GetRoleAsync(id);
        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole([FromBody] RoleForCreationDto role)
    {
        if (role is null)
            return BadRequest("RoleForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdRole = await _service.RoleService.CreateRoleAsync(role);
        return CreatedAtRoute("RoleById", new { id = createdRole.Id }, createdRole);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateRole(Guid id, [FromBody] RoleForUpdateDto role)
    {
        if (role is null)
            return BadRequest("RoleForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedRole = await _service.RoleService.UpdateRoleAsync(id, role);
        return Ok(updatedRole);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateRole(Guid id, 
        [FromBody] JsonPatchDocument<RoleForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roleToPatch, roleEntity) = await _service.RoleService.GetRoleForPatchAsync(id);
        patchDoc.ApplyTo(roleToPatch);

        TryValidateModel(roleToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedRole = await _service.RoleService.SaveChangesForPatchAsync(roleToPatch, roleEntity);
        return Ok(updatedRole);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRole(Guid id)
    {
        await _service.RoleService.DeleteRoleAsync(id);
        return NoContent();
    }
}