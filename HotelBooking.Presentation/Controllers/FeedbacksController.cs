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
    [Route("api/rooms/{reservationId:guid}/feedbacks")]
    public IActionResult GetFeedbacksForRoom(Guid reservationId)
    {
        var feedbacks = _service.FeedbackService.GetFeedbacksForRoom(reservationId, trackChanges: false);
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
    [Route("api/hotels/{hotelId:guid}/feedbacks/{id:guid}")]
    public IActionResult GetFeedbackForHotel(Guid hotelId, Guid id)
    {
        var feedback = _service.FeedbackService.GetFeedbackForHotel(hotelId, id, trackChanges: false);
        return Ok(feedback);
    }

    [HttpGet]
    [Route("api/rooms/{reservationId:guid}/feedbacks/{id:guid}")]
    public IActionResult GetFeedbackForRoom(Guid reservationId, Guid id)
    {
        var feedback = _service.FeedbackService.GetFeedbackForRoom(reservationId, id, trackChanges: false);
        return Ok(feedback);
    }

    [HttpGet("api/reservations/{reservationId:guid}/feedbacks/{id:guid}", Name = "GetFeedbackForReservation")]
    public IActionResult GetFeedbackForReservation(Guid reservationId, Guid id)
    {
        var feedback = _service.FeedbackService.GetFeedbackForReservation(reservationId, id, trackChanges: false);
        return Ok(feedback);
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

    [HttpDelete]
    [Route("api/feedbacks/{id:guid}")]
    public IActionResult DeleteFeedback(Guid id)
    {
        _service.FeedbackService.DeleteFeedback(id, trackChanges: false);
        return NoContent();
    }
}