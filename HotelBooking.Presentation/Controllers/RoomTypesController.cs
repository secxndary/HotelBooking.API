using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace HotelBooking.Presentation.Controllers;

[Route("api/roomTypes")]
[ApiController]
public class RoomTypesController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomTypesController(IServiceManager service) => _service = service;


    [HttpGet]
    public async Task<IActionResult> GetRoomTypes()
    {
        var roomTypes = await _service.RoomTypeService.GetAllRoomTypesAsync(trackChanges: false);
        return Ok(roomTypes);
    }

    [HttpGet("{id:guid}", Name = "RoomTypeById")]
    public async Task<IActionResult> GetRoomType(Guid id)
    {
        var roomType = await _service.RoomTypeService.GetRoomTypeAsync(id, trackChanges: false);
        return Ok(roomType);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoomType([FromBody] RoomTypeForCreationDto roomType)
    {
        if (roomType is null)
            return BadRequest("RoomTypeForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdRoomType = await _service.RoomTypeService.CreateRoomTypeAsync(roomType);
        return CreatedAtRoute("RoomTypeById", new { id = createdRoomType.Id }, createdRoomType);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateRoomType(Guid id, [FromBody] RoomTypeForUpdateDto roomType)
    {
        if (roomType is null)
            return BadRequest("RoomTypeForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.RoomTypeService.UpdateRoomTypeAsync(id, roomType, trackChanges: true);
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateRoomType(
        Guid id,
        [FromBody] JsonPatchDocument<RoomTypeForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roomTypeToPatch, roomTypeEntity) = await _service.RoomTypeService.GetRoomTypeForPatchAsync(id, trackChanges: true);
        patchDoc.ApplyTo(roomTypeToPatch);

        TryValidateModel(roomTypeToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.RoomTypeService.SaveChangesForPatchAsync(roomTypeToPatch, roomTypeEntity);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRoomType(Guid id)
    {
        await _service.RoomTypeService.DeleteRoomTypeAsync(id, trackChanges: false);
        return NoContent();
    }
}