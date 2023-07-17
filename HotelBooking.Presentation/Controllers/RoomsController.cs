using HotelBooking.Presentation.ModelBinders;
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
    public IActionResult GetRoomsForHotel(Guid hotelId)
    {
        var rooms = _service.RoomService.GetRooms(hotelId, trackChanges: false);
        return Ok(rooms);
    }

    [HttpGet("{id:guid}", Name = "GetRoomForHotel")]
    public IActionResult GetRoomForHotel(Guid hotelId, Guid id)
    {
        var room = _service.RoomService.GetRoom(hotelId, id, trackChanges: false);
        return Ok(room);
    }

    [HttpGet("collection/({ids})", Name = "RoomCollection")]
    public IActionResult GetRoomCollection(
        Guid hotelId,
        [ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var rooms = _service.RoomService.GetByIdsForHotel(hotelId, ids, trackChanges: false);
        return Ok(rooms);
    }

    [HttpPost]
    public IActionResult CreateRoom(Guid hotelId, [FromBody] RoomForCreationDto room)
    {
        if (room is null)
            return BadRequest("RoomForCreationDto object is null");
        var createdRoom = _service.RoomService.CreateRoomForHotel(hotelId, room, trackChanges: false);
        return CreatedAtRoute("GetRoomForHotel", new { hotelId, id = createdRoom.Id }, createdRoom);
    }

    [HttpPost("collection")]
    public IActionResult CreateRoomCollection(
        Guid hotelId, 
        [FromBody] IEnumerable<RoomForCreationDto> roomCollection)
    {
        var result = _service.RoomService.CreateRoomCollection(hotelId, roomCollection);
        return CreatedAtRoute("RoomCollection", new { hotelId, result.ids }, result.rooms);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateRoomForHotel(Guid hotelId, Guid id, [FromBody] RoomForUpdateDto room)
    {
        if (room is null)
            return BadRequest("RoomForUpdateDto object is null");
        _service.RoomService.UpdateRoomForHotel(hotelId, id, room,
            hotelTrackChanges: false, roomTrackChanges: true);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRoomForHotel(Guid hotelId, Guid id)
    {
        _service.RoomService.DeleteRoomForHotel(hotelId, id, trackChanges: false);
        return NoContent();
    }
}