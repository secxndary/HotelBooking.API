using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly IServiceManager _service;
    public HotelsController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetHotels()
    {
        var hotels = _service.HotelService.GetAllHotels(trackChanges: false);
        return Ok(hotels);
    }

    [Route("{id:guid}")]
    [HttpGet]
    public IActionResult GetHotel(Guid id)
    {
        var hotel = _service.HotelService.GetHotel(id, trackChanges: false);
        return Ok(hotel);
    }
}