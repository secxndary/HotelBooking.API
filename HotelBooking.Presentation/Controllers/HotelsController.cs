using HotelBooking.Presentation.ModelBinders;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects;
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

    [HttpGet("collection/({ids})", Name = "HotelCollection")]
    public IActionResult GetHotelCollection(
        [ModelBinder(typeof(ArrayModelBinder))]
        IEnumerable<Guid> ids)
    {
        var hotels = _service.HotelService.GetByIds(ids, trackChanges: false);
        return Ok(hotels);
    }

    [HttpGet("{id:guid}", Name = "HotelById")]
    public IActionResult GetHotel(Guid id)
    {
        var hotel = _service.HotelService.GetHotel(id, trackChanges: false);
        return Ok(hotel);
    }

    [HttpPost]
    public IActionResult CreateHotel([FromBody] HotelForCreationDto hotel)
    {
        if (hotel is null)
            return BadRequest("HotelForCreationDto object is null");
        var createdHotel = _service.HotelService.CreateHotel(hotel);
        return CreatedAtRoute("HotelById", new { id = createdHotel.Id }, createdHotel);
    }

    [HttpPost("collection")]
    public IActionResult CreateHotelCollection(
        [FromBody] 
        IEnumerable<HotelForCreationDto> hotelCollection)
    {
        var result = _service.HotelService.CreateHotelCollection(hotelCollection);
        return CreatedAtRoute("HotelCollection", new { result.ids }, result.hotels);
    }
}