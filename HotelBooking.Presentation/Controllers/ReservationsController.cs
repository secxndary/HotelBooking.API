using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/rooms/{roomId}/reservations")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly IServiceManager _service;
    public ReservationsController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetReservations()
    {
        var reservations = _service.ReservationService.GetAllReservations(trackChanges: false);
        return Ok(reservations);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetReservation(Guid id)
    {
        var reservation = _service.ReservationService.GetReservation(id, trackChanges: false);
        return Ok(reservation);
    }
}