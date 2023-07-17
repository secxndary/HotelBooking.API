using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;

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

    [HttpPost]
    public IActionResult CreateHotelPhoto(Guid hotelId, [FromBody] HotelPhotoForCreationDto hotelPhoto)
    {
        if (hotelPhoto is null)
            return BadRequest("HotelPhotoForCreationDto object is null");
        var createdHotelPhoto = _service.HotelPhotoService.CreateHotelPhoto(hotelId, hotelPhoto, trackChanges: false);
        return CreatedAtRoute("GetHotelPhotoForHotel", new { hotelId, id = createdHotelPhoto.Id }, createdHotelPhoto);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteHotelPhoto(Guid hotelId, Guid id)
    {
        _service.HotelPhotoService.DeleteHotelPhoto(hotelId, id, trackChanges: false);
        return NoContent();
    }
}