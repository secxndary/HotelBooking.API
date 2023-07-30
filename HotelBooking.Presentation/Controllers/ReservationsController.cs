using System.Text.Json;
using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

[Route("api/rooms/{roomId:guid}/reservations")]
[ApiController]
public class ReservationsController : ControllerBase
{
    private readonly IServiceManager _service;
    public ReservationsController(IServiceManager service) => _service = service;


    [HttpGet]
    [HttpHead]
    public async Task<IActionResult> GetReservations(Guid roomId, [FromQuery] ReservationlParameters reservationlParameters)
    {
        var (reservations, metaData) = await _service.ReservationService.GetReservationsAsync(roomId, reservationlParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(reservations);
    }

    [HttpGet("{id:guid}", Name = "ReservationById")]
    public async Task<IActionResult> GetReservation(Guid roomId, Guid id)
    {
        var reservation = await _service.ReservationService.GetReservationAsync(roomId, id);
        return Ok(reservation);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateReservation(Guid roomId, [FromBody] ReservationForCreationDto reservation)
    {
        var createdReservation = await _service.ReservationService.CreateReservationForRoomAsync(roomId, reservation);
        return CreatedAtRoute("ReservationById", new { roomId, id = createdReservation.Id }, createdReservation);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateReservation(Guid roomId, Guid id, 
        [FromBody] ReservationForUpdateDto reservation)
    {
        var updatedReservation = await _service.ReservationService.UpdateReservationForRoomAsync(roomId, id, reservation);
        return Ok(updatedReservation);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateReservation(Guid roomId, Guid id,
        [FromBody] JsonPatchDocument<ReservationForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (reservationToPatch, reservationEntity) = await _service.ReservationService.GetReservationForPatchAsync(roomId, id);
        patchDoc.ApplyTo(reservationToPatch);

        TryValidateModel(reservationToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedReservation = await _service.ReservationService.SaveChangesForPatchAsync(reservationToPatch, reservationEntity);
        return Ok(updatedReservation);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteReservationForRoom(Guid roomId, Guid id)
    {
        await _service.ReservationService.DeleteReservationForRoomAsync(roomId, id);
        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetReservationsOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}