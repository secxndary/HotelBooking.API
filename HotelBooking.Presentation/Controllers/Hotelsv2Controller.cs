using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

//[ApiVersion("2.0", Deprecated = true)]
[Route("api/hotels")]
[ApiController]
public class Hotelsv2Controller : ControllerBase
{
    private readonly IServiceManager _service;
    public Hotelsv2Controller(IServiceManager service) => _service = service;


    [HttpGet]
    public async Task<IActionResult> GetHotels([FromQuery] HotelParameters hotelParameters)
    {
        var (hotels, metadata) = await _service.HotelService.GetAllHotelsAsync(hotelParameters);
        return Ok(hotels.Select(h => $"{h.Name} V2"));
    }
}