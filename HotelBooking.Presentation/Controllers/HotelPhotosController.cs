using HotelBooking.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels/{hotelId:guid}/photos")]
[ApiController]
public class HotelPhotosController : ControllerBase
{
    private readonly IServiceManager _service;
    public HotelPhotosController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetHotelPhotos(Guid hotelId)
    {
        var hotelPhotos = _service.HotelPhotoService.GetHotelPhotos(hotelId, trackChanges: false);
        return Ok(hotelPhotos);
    }

    [HttpGet("{id:guid}", Name = "GetHotelPhotoForHotel")]
    public IActionResult GetHotelPhoto(Guid hotelId, Guid id)
    {
        var hotelPhoto = _service.HotelPhotoService.GetHotelPhoto(hotelId, id, trackChanges: false);
        return Ok(hotelPhoto);
    }

    [HttpGet("collection/({ids})", Name = "HotelPhotoCollection")]
    public IActionResult GetHotelPhotoCollection(
        Guid hotelId,
        [ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var hotelPhotos = _service.HotelPhotoService.GetByIds(hotelId, ids, trackChanges: false);
        return Ok(hotelPhotos);
    }

    [HttpPost]
    public IActionResult CreateHotelPhoto(Guid hotelId, [FromBody] HotelPhotoForCreationDto hotelPhoto)
    {
        if (hotelPhoto is null)
            return BadRequest("HotelPhotoForCreationDto object is null");
        var createdHotelPhoto = _service.HotelPhotoService.CreateHotelPhoto(hotelId, hotelPhoto, trackChanges: false);
        return CreatedAtRoute("GetHotelPhotoForHotel", new { hotelId, id = createdHotelPhoto.Id }, createdHotelPhoto);
    }

    [HttpPost("collection")]
    public IActionResult CreateHotelPhotoCollection(
        Guid hotelId,
        [FromBody] IEnumerable<HotelPhotoForCreationDto> hotelPhotoCollection)
    {
        var result = _service.HotelPhotoService.CreateHotelPhotoCollection(hotelId, hotelPhotoCollection);
        return CreatedAtRoute("HotelPhotoCollection", new { hotelId, result.ids }, result.hotelPhotos);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateHotelPhoto(Guid hotelId, Guid id, [FromBody] HotelPhotoForUpdateDto photo)
    {
        if (photo is null)
            return BadRequest("HotelPhotoForUpdateDto object is null");
        _service.HotelPhotoService.UpdateHotelPhoto(hotelId, id, photo, 
            hotelTrackChanges: false, photoTrackChanges: true);
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateHotelPhoto(Guid hotelId, Guid id,
        [FromBody] JsonPatchDocument<HotelPhotoForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (hotelPhotoToPatch, hotelPhotoEntity) = _service.HotelPhotoService.GetHotelPhotoForPatch
            (hotelId, id, hotelTrackChanges: false, photoTrackChanges: true);
        patchDoc.ApplyTo(hotelPhotoToPatch);

        _service.HotelPhotoService.SaveChangesForPatch(hotelPhotoToPatch, hotelPhotoEntity);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteHotelPhoto(Guid hotelId, Guid id)
    {
        _service.HotelPhotoService.DeleteHotelPhoto(hotelId, id, trackChanges: false);
        return NoContent();
    }
}