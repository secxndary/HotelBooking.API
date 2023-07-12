using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels/{hotelId}/feedbacks")]
[ApiController]
public class FeedbacksController : ControllerBase
{
    private readonly IServiceManager _service;
    public FeedbacksController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetFeedbacksForHotel(Guid hotelId)
    {
        var feedbacks = _service.FeedbackService.GetFeedbacks(hotelId, trackChanges: false);
        return Ok(feedbacks);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetFeedbackForHotel(Guid hotelId, Guid id)
    {
        var feedback = _service.FeedbackService.GetFeedback(hotelId, id, trackChanges: false);
        return Ok(feedback);
    }
}