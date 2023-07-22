using HotelBooking.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace HotelBooking.Presentation.Controllers;

[Route("api/rooms/{roomId:guid}/photos")]
[ApiController]
public class RoomPhotosController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomPhotosController(IServiceManager service) => _service = service;


    [HttpGet]
    public async Task<IActionResult> GetRoomPhotos(Guid roomId)
    {
        var roomPhotos = await _service.RoomPhotoService.GetRoomPhotosAsync(roomId, trackChanges: false);
        return Ok(roomPhotos);
    }

    [HttpGet("{id:guid}", Name = "GetRoomPhotoForRoom")]
    public async Task<IActionResult> GetRoomPhoto(Guid roomId, Guid id)
    {
        var roomPhoto = await _service.RoomPhotoService.GetRoomPhotoAsync(roomId, id, trackChanges: false);
        return Ok(roomPhoto);
    }

    [HttpGet("collection/({ids})", Name = "RoomPhotoCollection")]
    public async Task<IActionResult> GetRoomPhotoCollection(
        Guid roomId,
        [ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var roomPhotos = await _service.RoomPhotoService.GetByIdsAsync(roomId, ids, trackChanges: false);
        return Ok(roomPhotos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRoomPhoto(Guid roomId, [FromBody] RoomPhotoForCreationDto roomPhoto)
    {
        if (roomPhoto is null)
            return BadRequest("RoomPhotoForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdRoomPhoto = await _service.RoomPhotoService.CreateRoomPhotoAsync(roomId, roomPhoto, trackChanges: false);
        return CreatedAtRoute("GetRoomPhotoForRoom", new { roomId, id = createdRoomPhoto.Id }, createdRoomPhoto);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateRoomPhotoCollection(
        Guid roomId,
        [FromBody] IEnumerable<RoomPhotoForCreationDto> roomPhotoCollection)
    {
        var (roomPhotos, ids) = await _service.RoomPhotoService.CreateRoomPhotoCollectionAsync
            (roomId, roomPhotoCollection);
        return CreatedAtRoute("RoomPhotoCollection", new { roomId, ids }, roomPhotos);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateRoomPhoto(Guid roomId, Guid id, [FromBody] RoomPhotoForUpdateDto photo)
    {
        if (photo is null)
            return BadRequest("RoomPhotoForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.RoomPhotoService.UpdateRoomPhotoAsync(roomId, id, photo,
            roomTrackChanges: false, photoTrackChanges: true);
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateRoomPhoto(Guid roomId, Guid id,
        [FromBody] JsonPatchDocument<RoomPhotoForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roomPhotoToPatch, roomPhotoEntity) = await _service.RoomPhotoService.GetRoomPhotoForPatchAsync
            (roomId, id, roomTrackChanges: false, photoTrackChanges: true);
        patchDoc.ApplyTo(roomPhotoToPatch);

        TryValidateModel(roomPhotoToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        await _service.RoomPhotoService.SaveChangesForPatchAsync(roomPhotoToPatch, roomPhotoEntity);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRoomPhoto(Guid roomId, Guid id)
    {
        await _service.RoomPhotoService.DeleteRoomPhotoAsync(roomId, id, trackChanges: false);
        return NoContent();
    }
}