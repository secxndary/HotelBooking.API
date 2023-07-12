using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/roomPhotos")]
[ApiController]
public class RoomPhotosController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomPhotosController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetRoomPhotos()
    {
        var roomPhotos = _service.RoomPhotoService.GetAllRoomPhotos(trackChanges: false);
        return Ok(roomPhotos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRoomPhoto(Guid id)
    {
        var roomPhoto = _service.RoomPhotoService.GetRoomPhoto(id, trackChanges: false);
        return Ok(roomPhoto);
    }
}