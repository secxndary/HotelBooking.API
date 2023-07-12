using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels/{hotelId}/photos")]
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

    [HttpGet("{id:guid}")]
    public IActionResult GetHotelPhoto(Guid hotelId, Guid id)
    {
        var hotelPhoto = _service.HotelPhotoService.GetHotelPhoto(hotelId, id, trackChanges: false);
        return Ok(hotelPhoto);
    }
}