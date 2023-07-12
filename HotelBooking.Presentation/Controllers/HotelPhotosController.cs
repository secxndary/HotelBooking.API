using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotelPhotos")]
[ApiController]
public class HotelPhotosController : ControllerBase
{
    private readonly IServiceManager _service;
    public HotelPhotosController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetHotelPhotos()
    {
        var hotelPhotos = _service.HotelPhotoService.GetAllHotelPhotos(trackChanges: false);
        return Ok(hotelPhotos);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetHotelPhoto(Guid id)
    {
        var hotelPhoto = _service.HotelPhotoService.GetHotelPhoto(id, trackChanges: false);
        return Ok(hotelPhoto);
    }
}