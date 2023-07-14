using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
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
    [Route("api/hotels/{hotelId:guid}/feedbacks/{id:guid}")]
    public IActionResult GetFeedbackForHotel(Guid hotelId, Guid id)
    {
        var feedback = _service.FeedbackService.GetFeedbackForHotel(hotelId, id, trackChanges: false);
        return Ok(feedback);
    }

    [HttpGet]
    [Route("api/rooms/{roomId:guid}/feedbacks/{id:guid}")]
    public IActionResult GetFeedbackForRoom(Guid roomId, Guid id)
    {
        var feedback = _service.FeedbackService.GetFeedbackForRoom(roomId, id, trackChanges: false);
        return Ok(feedback);
    }

    [HttpGet]
    [Route("api/reservations/{reservationId:guid}/feedbacks/{id:guid}")]
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

    [HttpDelete]
    [Route("api/hotels/{hotelId:guid}/feedbacks/{id:guid}")]
    public IActionResult DeleteFeedbackForHotel(Guid hotelId, Guid id)
    {
        _service.FeedbackService.DeleteFeedbackForHotel(hotelId, id, trackChanges: false);
        return NoContent();
    }

    [HttpDelete]
    [Route("api/rooms/{roomId:guid}/feedbacks/{id:guid}")]
    public IActionResult DeleteFeedbackForRoom(Guid roomId, Guid id)
    {
        _service.FeedbackService.DeleteFeedbackForRoom(roomId, id, trackChanges: false);
        return NoContent();
    }

    [HttpDelete]
    [Route("api/reservations/{reservationId:guid}/feedbacks/{id:guid}")]
    public IActionResult DeleteFeedbackForReservation(Guid reservationId, Guid id)
    {
        _service.FeedbackService.DeleteFeedbackForReservation(reservationId, id, trackChanges: false);
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