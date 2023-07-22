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
    public async Task<IActionResult> GetHotelPhotos(Guid hotelId)
    {
        var hotelPhotos = await _service.HotelPhotoService.GetHotelPhotosAsync(hotelId);
        return Ok(hotelPhotos);
    }

    [HttpGet("{id:guid}", Name = "GetHotelPhotoForHotel")]
    public async Task<IActionResult> GetHotelPhoto(Guid hotelId, Guid id)
    {
        var hotelPhoto = await _service.HotelPhotoService.GetHotelPhotoAsync(hotelId, id);
        return Ok(hotelPhoto);
    }

    [HttpGet("collection/({ids})", Name = "HotelPhotoCollection")]
    public async Task<IActionResult> GetHotelPhotoCollection(
        Guid hotelId,
        [ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var hotelPhotos = await _service.HotelPhotoService.GetByIdsAsync(hotelId, ids);
        return Ok(hotelPhotos);
    }

    [HttpPost]
    public async Task<IActionResult> CreateHotelPhoto(Guid hotelId, [FromBody] HotelPhotoForCreationDto hotelPhoto)
    {
        if (hotelPhoto is null)
            return BadRequest("HotelPhotoForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdHotelPhoto = await _service.HotelPhotoService.CreateHotelPhotoAsync(hotelId, hotelPhoto);
        return CreatedAtRoute("GetHotelPhotoForHotel", new { hotelId, id = createdHotelPhoto.Id }, createdHotelPhoto);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateHotelPhotoCollection(Guid hotelId,
        [FromBody] IEnumerable<HotelPhotoForCreationDto> hotelPhotoCollection)
    {
        var (hotelPhotos, ids) = await _service.HotelPhotoService.CreateHotelPhotoCollectionAsync
            (hotelId, hotelPhotoCollection);
        return CreatedAtRoute("HotelPhotoCollection", new { hotelId, ids }, hotelPhotos);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> UpdateHotelPhoto(Guid hotelId, Guid id, [FromBody] HotelPhotoForUpdateDto photo)
    {
        if (photo is null)
            return BadRequest("HotelPhotoForUpdateDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedHotelPhoto = await _service.HotelPhotoService.UpdateHotelPhotoAsync(hotelId, id, photo);
        return Ok(updatedHotelPhoto);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateHotelPhoto(Guid hotelId, Guid id,
        [FromBody] JsonPatchDocument<HotelPhotoForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (hotelPhotoToPatch, hotelPhotoEntity) = await _service.HotelPhotoService.GetHotelPhotoForPatchAsync(hotelId, id);
        patchDoc.ApplyTo(hotelPhotoToPatch);

        TryValidateModel(hotelPhotoToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedHotelPhoto = await _service.HotelPhotoService.SaveChangesForPatchAsync(hotelPhotoToPatch, hotelPhotoEntity);
        return Ok(updatedHotelPhoto);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteHotelPhoto(Guid hotelId, Guid id)
    {
        await _service.HotelPhotoService.DeleteHotelPhotoAsync(hotelId, id);
        return NoContent();
    }
}