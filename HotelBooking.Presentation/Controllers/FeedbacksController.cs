using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace HotelBooking.Presentation.Controllers;

[ApiController]
public class FeedbacksController : ControllerBase
{
    private readonly IServiceManager _service;
    public FeedbacksController(IServiceManager service) => _service = service;


    [HttpGet]
    [Route("api/hotels/{hotelId:guid}/feedbacks")]
    public async Task<IActionResult> GetFeedbacksForHotel(Guid hotelId)
    {
        var feedbacks = await _service.FeedbackService.GetFeedbacksForHotelAsync(hotelId);
        return Ok(feedbacks);
    }

    [HttpGet]
    [Route("api/rooms/{roomId:guid}/feedbacks")]
    public async Task<IActionResult> GetFeedbacksForRoom(Guid roomId)
    {
        var feedbacks = await _service.FeedbackService.GetFeedbacksForRoomAsync(roomId);
        return Ok(feedbacks);
    }

    [HttpGet]
    [Route("api/reservations/{reservationId:guid}/feedbacks")]
    public async Task<IActionResult> GetFeedbacksForReservation(Guid reservationId)
    {
        var feedbacks = await _service.FeedbackService.GetFeedbacksForReservationAsync(reservationId);
        return Ok(feedbacks);
    }

    [HttpGet]
    [Route("api/feedbacks/{id:guid}")]
    public async Task<IActionResult> GetFeedback(Guid id)
    {
        var feedback = await _service.FeedbackService.GetFeedbackAsync(id);
        return Ok(feedback);
    }

    [HttpPost]
    [Route("api/reservations/{reservationId:guid}/feedbacks")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateFeedback(Guid reservationId, [FromBody] FeedbackForCreationDto feedback)
    {
        var createdFeedback = await _service.FeedbackService.CreateFeedbackForReservationAsync(reservationId, feedback);
        return CreatedAtRoute("GetFeedbackForReservation", new { reservationId, id = createdFeedback.Id }, createdFeedback);
    }

    [HttpPut("api/feedbacks/{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateFeedback(Guid id, [FromBody] FeedbackForUpdateDto feedback)
    {
        var updatedFeedback = await _service.FeedbackService.UpdateFeedbackAsync(id, feedback);
        return Ok(updatedFeedback);
    }

    [HttpPatch("api/feedbacks/{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateFeedback(Guid id, 
        [FromBody] JsonPatchDocument<FeedbackForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (feedbackToPatch, feedbackEntity) = await _service.FeedbackService.GetFeedbackForPatchAsync(id);
        patchDoc.ApplyTo(feedbackToPatch);

        TryValidateModel(feedbackToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedFeedback = await _service.FeedbackService.SaveChangesForPatchAsync(feedbackToPatch, feedbackEntity);
        return Ok(updatedFeedback);
    }

    [HttpDelete("api/feedbacks/{id:guid}")]
    public async Task<IActionResult> DeleteFeedback(Guid id)
    {
        await _service.FeedbackService.DeleteFeedbackAsync(id);
        return NoContent();
    }
}