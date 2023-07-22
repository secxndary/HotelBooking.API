using HotelBooking.Presentation.Filters.ActionFilters;
using HotelBooking.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels/{hotelId:guid}/rooms")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomsController(IServiceManager service) => _service = service;


    [HttpGet]
    public async Task<IActionResult> GetRoomsForHotel(Guid hotelId)
    {
        var rooms = await _service.RoomService.GetRoomsAsync(hotelId);
        return Ok(rooms);
    }

    [HttpGet("{id:guid}", Name = "GetRoomForHotel")]
    public async Task<IActionResult> GetRoomForHotel(Guid hotelId, Guid id)
    {
        var room = await _service.RoomService.GetRoomAsync(hotelId, id);
        return Ok(room);
    }

    [HttpGet("collection/({ids})", Name = "RoomCollection")]
    public async Task<IActionResult> GetRoomCollection(Guid hotelId,
        [ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var rooms = await _service.RoomService.GetByIdsForHotelAsync(hotelId, ids);
        return Ok(rooms);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateRoom(Guid hotelId, [FromBody] RoomForCreationDto room)
    {
        var createdRoom = await _service.RoomService.CreateRoomForHotelAsync(hotelId, room);
        return CreatedAtRoute("GetRoomForHotel", new { hotelId, id = createdRoom.Id }, createdRoom);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateRoomCollection(Guid hotelId, 
        [FromBody] IEnumerable<RoomForCreationDto> roomCollection)
    {
        var (rooms, ids) = await _service.RoomService.CreateRoomCollectionAsync(hotelId, roomCollection);
        return CreatedAtRoute("RoomCollection", new { hotelId, ids }, rooms);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateRoomForHotel(Guid hotelId, Guid id, [FromBody] RoomForUpdateDto room)
    {
        var updatedRoom = await _service.RoomService.UpdateRoomForHotelAsync(hotelId, id, room);
        return Ok(updatedRoom);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateRoomForHotel(Guid hotelId, Guid id,
        [FromBody] JsonPatchDocument<RoomForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roomToPatch, roomEntity) = await _service.RoomService.GetRoomForPatchAsync(hotelId, id);
        patchDoc.ApplyTo(roomToPatch, ModelState);

        TryValidateModel(roomToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedRoom = await _service.RoomService.SaveChangesForPatchAsync(roomToPatch, roomEntity);
        return Ok(updatedRoom);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRoomForHotel(Guid hotelId, Guid id)
    {
        await _service.RoomService.DeleteRoomForHotelAsync(hotelId, id);
        return NoContent();
    }
}