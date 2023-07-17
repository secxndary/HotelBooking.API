using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
namespace HotelBooking.Presentation.Controllers;

[Route("api/rooms/{roomId:guid}/photos")]
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

    [HttpGet("{id:guid}", Name = "GetRoomPhotoForRoom")]
    public IActionResult GetRoomPhoto(Guid roomId, Guid id)
    {
        var roomPhoto = _service.RoomPhotoService.GetRoomPhoto(roomId, id, trackChanges: false);
        return Ok(roomPhoto);
    }

    [HttpPost]
    public IActionResult CreateRoomPhoto(Guid roomId, [FromBody] RoomPhotoForCreationDto roomPhoto)
    {
        if (roomPhoto is null)
            return BadRequest("RoomPhotoForCreationDto object is null");
        var createdRoomPhoto = _service.RoomPhotoService.CreateRoomPhoto(roomId, roomPhoto, trackChanges: false);
        return CreatedAtRoute("GetRoomPhotoForRoom", new { roomId, id = createdRoomPhoto.Id }, createdRoomPhoto);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteRoomPhoto(Guid roomId, Guid id)
    {
        _service.RoomPhotoService.DeleteRoomPhoto(roomId, id, trackChanges: false);
        return NoContent();
    }
}