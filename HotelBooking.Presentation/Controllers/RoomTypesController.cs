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
    public IActionResult GetRoomTypes()
    {
        var roomTypes = _service.RoomTypeService.GetAllRoomTypes(trackChanges: false);
        return Ok(roomTypes);
    }

    [HttpGet("{id:guid}", Name = "RoomTypeById")]
    public IActionResult GetRoomType(Guid id)
    {
        var roomType = _service.RoomTypeService.GetRoomType(id, trackChanges: false);
        return Ok(roomType);
    }

    [HttpPost]
    public IActionResult CreateRoomType([FromBody] RoomTypeForCreationDto roomType)
    {
        if (roomType is null)
            return BadRequest("RoomTypeForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdRoomType = _service.RoomTypeService.CreateRoomType(roomType);
        return CreatedAtRoute("RoomTypeById", new { id = createdRoomType.Id }, createdRoomType);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateRoomType(Guid id, [FromBody] RoomTypeForUpdateDto roomType)
    {
        if (roomType is null)
            return BadRequest("RoomTypeForUpdateDto object is null");
        _service.RoomTypeService.UpdateRoomType(id, roomType, trackChanges: true);
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateRoomType(
        Guid id,
        [FromBody] JsonPatchDocument<RoomTypeForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roomTypeToPatch, roomTypeEntity) = _service.RoomTypeService.GetRoomTypeForPatch(id, trackChanges: true);
        patchDoc.ApplyTo(roomTypeToPatch);

        _service.RoomTypeService.SaveChangesForPatch(roomTypeToPatch, roomTypeEntity);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRoomType(Guid id)
    {
        _service.RoomTypeService.DeleteRoomType(id, trackChanges: false);
        return NoContent();
    }
}