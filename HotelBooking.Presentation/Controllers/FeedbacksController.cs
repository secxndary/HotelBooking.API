using System.Text.Json;
using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

[ApiController]
[Authorize]
public class FeedbacksController : ControllerBase
{
    private readonly IServiceManager _service;
    public FeedbacksController(IServiceManager service) => _service = service;


    [HttpGet]
    [HttpHead]
    [Route("api/hotels/{hotelId:guid}/feedbacks")]
    public async Task<IActionResult> GetFeedbacksForHotel(Guid hotelId, [FromQuery] FeedbackParameters feedbackParameters)
    {
        var (feedbacks, metaData) = await _service.FeedbackService.GetFeedbacksForHotelAsync(hotelId, feedbackParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(feedbacks);
    }

    [HttpGet]
    [HttpHead]
    [Route("api/rooms/{roomId:guid}/feedbacks")]
    public async Task<IActionResult> GetFeedbacksForRoom(Guid roomId)
    {
        var feedbacks = await _service.FeedbackService.GetFeedbacksForRoomAsync(roomId);
        return Ok(feedbacks);
    }

    [HttpGet]
    [HttpHead]
    [Route("api/reservations/{reservationId:guid}/feedbacks")]
    public async Task<IActionResult> GetFeedbacksForReservation(Guid reservationId)
    {
        var feedbacks = await _service.FeedbackService.GetFeedbacksForReservationAsync(reservationId);
        return Ok(feedbacks);
    }

    [HttpGet]
    [Route("api/feedbacks/{id:guid}", Name = "FeedbackById")]
    public async Task<IActionResult> GetFeedback(Guid id)
    {
        var feedback = await _service.FeedbackService.GetFeedbackAsync(id);
        return Ok(feedback);
    }

    [HttpPost]
    [Authorize(Roles = "User")]
    [Route("api/feedbacks", Name = "CreateFeedback")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateFeedback([FromBody] FeedbackForCreationDto feedback)
    {
        var createdFeedback = await _service.FeedbackService.CreateFeedbackAsync(feedback);
        return CreatedAtRoute("FeedbackById", new { id = createdFeedback.Id }, createdFeedback);
    }

    [HttpPut("api/feedbacks/{id:guid}")]
    [Authorize(Roles = "User")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateFeedback(Guid id, [FromBody] FeedbackForUpdateDto feedback)
    {
        var updatedFeedback = await _service.FeedbackService.UpdateFeedbackAsync(id, feedback);
        return Ok(updatedFeedback);
    }

    [HttpPatch("api/feedbacks/{id:guid}")]
    [Authorize(Roles = "User")]
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
    [Authorize(Roles = "User, Admin")]
    public async Task<IActionResult> DeleteFeedback(Guid id)
    {
        await _service.FeedbackService.DeleteFeedbackAsync(id);
        return NoContent();
    }

    [HttpOptions("api/feedbacks")]
    public IActionResult GetFeedbacksOptions()
    {
        Response.Headers.Add("Allow", "OPTIONS, POST");
        return Ok();
    }

    [HttpOptions("api/hotels/{hotelId:guid}/feedbacks")]
    public IActionResult GetFeedbacksByHotelOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS");
        return Ok();
    }

    [HttpOptions("api/rooms/{roomId:guid}/feedbacks")]
    public IActionResult GetFeedbacksByRoomOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS");
        return Ok();
    }

    [HttpOptions("api/reservations/{reservationId:guid}/feedbacks")]
    public IActionResult GetFeedbacksByReservationOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS");
        return Ok();
    }
}