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
    public IActionResult GetFeedbacksForHotel(Guid hotelId)
    {
        var feedbacks = _service.FeedbackService.GetFeedbacksForHotel(hotelId, trackChanges: false);
        return Ok(feedbacks);
    }

    [HttpGet]
    [Route("api/rooms/{roomId:guid}/feedbacks")]
    public IActionResult GetFeedbacksForRoom(Guid roomId)
    {
        var feedbacks = _service.FeedbackService.GetFeedbacksForRoom(roomId, trackChanges: false);
        return Ok(feedbacks);
    }

    [HttpGet]
    [Route("api/reservations/{reservationId:guid}/feedbacks")]
    public IActionResult GetFeedbacksForReservation(Guid reservationId)
    {
        var feedbacks = _service.FeedbackService.GetFeedbacksForReservation(reservationId, trackChanges: false);
        return Ok(feedbacks);
    }

    [HttpGet]
    [Route("api/feedbacks/{id:guid}")]
    public IActionResult GetFeedback(Guid id)
    {
        var feedback = _service.FeedbackService.GetFeedback(id, trackChanges: false);
        return Ok(feedback);
    }

    [HttpPost]
    [Route("api/reservations/{reservationId:guid}/feedbacks")]
    public IActionResult CreateFeedback(Guid reservationId, [FromBody] FeedbackForCreationDto feedback)
    {
        if (feedback is null)
            return BadRequest("FeedbackForCreationDto object is null");
        var createdFeedback = _service.FeedbackService.CreateFeedbackForReservation(reservationId, feedback, false);
        return CreatedAtRoute("GetFeedbackForReservation", new { reservationId, id = createdFeedback.Id }, createdFeedback);
    }

    [HttpPut("api/feedbacks/{id:guid}")]
    public IActionResult UpdateFeedback(Guid id, [FromBody] FeedbackForUpdateDto feedback)
    {
        if (feedback is null)
            return BadRequest("FeedbackForUpdateDto object is null");
        _service.FeedbackService.UpdateFeedback(id, feedback, trackChanges: true);
        return NoContent();
    }

    [HttpPatch("api/feedbacks/{id:guid}")]
    public IActionResult PartiallyUpdateFeedback(
        Guid id,
        [FromBody] JsonPatchDocument<FeedbackForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (feedbackToPatch, feedbackEntity) = _service.FeedbackService.GetFeedbackForPatch(id, trackChanges: true);
        patchDoc.ApplyTo(feedbackToPatch);

        _service.FeedbackService.SaveChangesForPatch(feedbackToPatch, feedbackEntity);
        return NoContent();
    }

    [HttpDelete]
    [Route("api/feedbacks/{id:guid}")]
    public IActionResult DeleteFeedback(Guid id)
    {
        _service.FeedbackService.DeleteFeedback(id, trackChanges: false);
        return NoContent();
    }
}