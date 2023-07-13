using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels/{hotelId}/rooms")]
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

    [HttpPost]
    public IActionResult CreateRoom(Guid hotelId, [FromBody] RoomForCreationDto room)
    {
        if (room is null)
            return BadRequest("RoomForCreationDto object is null");
        var createdRoom = _service.RoomService.CreateRoomForHotel(hotelId, room, trackChanges: false);
        return CreatedAtRoute("GetRoomForHotel", new { hotelId, id = createdRoom.Id }, createdRoom);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRoomForHotel(Guid hotelId, Guid id)
    {
        _service.RoomService.DeleteRoomForHotel(hotelId, id, trackChanges: false);
        return NoContent();
    }
}