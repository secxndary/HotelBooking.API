using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels/{hotelId}/feedbacks")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly IServiceManager _service;
    public ReservationsController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetReservationsForHotel(Guid hotelId)
    {
        var feedbacks = _service.ReservationService.GetReservations(hotelId, trackChanges: false);
        return Ok(feedbacks);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetReservationForHotel(Guid hotelId, Guid id)
    {
        var feedback = _service.ReservationService.GetReservation(hotelId, id, trackChanges: false);
        return Ok(feedback);
    }
}