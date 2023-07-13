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
    public IActionResult GetReservations(Guid roomId)
    {
        var reservations = _service.ReservationService.GetReservations(roomId, trackChanges: false);
        return Ok(reservations);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetReservation(Guid roomId, Guid id)
    {
        var reservation = _service.ReservationService.GetReservation(roomId, id, trackChanges: false);
        return Ok(reservation);
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteReservationForRoom(Guid roomId, Guid id)
    {
        _service.ReservationService.DeleteReservationForRoom(roomId, id, trackChanges: false);
        return NoContent();
    }
}