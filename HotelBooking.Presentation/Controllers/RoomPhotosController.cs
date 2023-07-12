using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels/{hotelId}/rooms/{roomId}/photos")]
[ApiController]
public class RoomPhotosController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomPhotosController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetRoomPhotos(Guid roomId)
    {
        var roomPhotos = _service.RoomPhotoService.GetRoomPhotos(roomId, trackChanges: false);
        return Ok(roomPhotos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRoomPhoto(Guid roomId, Guid id)
    {
        var roomPhoto = _service.RoomPhotoService.GetRoomPhoto(roomId, id, trackChanges: false);
        return Ok(roomPhoto);
    }
}