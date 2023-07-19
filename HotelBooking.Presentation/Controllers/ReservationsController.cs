using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;

namespace HotelBooking.Presentation.Controllers;

[Route("api/rooms/{roomId:guid}/reservations")]
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

    [HttpGet("{id:guid}", Name = "ReservationById")]
    public IActionResult GetReservation(Guid roomId, Guid id)
    {
        var reservation = _service.ReservationService.GetReservation(roomId, id, trackChanges: false);
        return Ok(reservation);
    }

    [HttpPost]
    public IActionResult CreateReservation(Guid roomId, [FromBody] ReservationForCreationDto reservation)
    {
        if (reservation is null)
            return BadRequest("ReservationForCreationDto object is null");
        var createdReservation = _service.ReservationService
            .CreateReservationForRoom(roomId, reservation, trackChanges: false);
        return CreatedAtRoute("ReservationById", new { roomId, id = createdReservation.Id }, createdReservation);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateReservation(Guid roomId, Guid id, [FromBody] ReservationForUpdateDto reservation)
    {
        if (reservation is null)
            return BadRequest("ReservationForUpdateDto object is null");
        _service.ReservationService.UpdateReservationForRoom(roomId, id, reservation, trackChanges: true);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteReservationForRoom(Guid roomId, Guid id)
    {
        _service.ReservationService.DeleteReservationForRoom(roomId, id, trackChanges: false);
        return NoContent();
    }
}