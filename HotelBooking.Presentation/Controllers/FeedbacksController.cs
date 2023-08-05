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
[Consumes("application/json")]
[Produces("application/json", "text/xml", "text/csv")]
public class FeedbacksController : ControllerBase
{
    private readonly IServiceManager _service;
    public FeedbacksController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of feedbacks by hotel
    /// </summary>
    /// <param name="hotelId"></param>
    /// <param name="feedbackParameters"></param>
    /// <returns>Feedbacks list</returns>
    /// <remarks>
    /// If the hotel with hotelId does not exist, the response code will be 404. <br /> <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If query parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [Route("api/hotels/{hotelId:guid}/feedbacks")]
    public async Task<IActionResult> GetFeedbacksForHotel(Guid hotelId, [FromQuery] FeedbackParameters feedbackParameters)
    {
        var (feedbacks, metaData) = await _service.FeedbackService.GetFeedbacksForHotelAsync(hotelId, feedbackParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(feedbacks);
    }

    /// <summary>
    /// Gets the list of feedbacks by room
    /// </summary>
    /// <param name="roomId"></param>
    /// <param name="feedbackParameters"></param>
    /// <returns>Feedbacks list</returns>
    /// <remarks>
    /// If the hotel with hotelId does not exist, the response code will be 404. <br /> <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If query parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
    [HttpGet]
    [HttpHead]
    [Route("api/rooms/{roomId:guid}/feedbacks")]
    public async Task<IActionResult> GetFeedbacksForRoom(Guid roomId)
    {
        var feedbacks = await _service.FeedbackService.GetFeedbacksForRoomAsync(roomId);
        return Ok(feedbacks);
    }

    /// <summary>
    /// Gets the list of feedbacks by reservation
    /// </summary>
    /// <param name="reservationId"></param>
    /// <param name="feedbackParameters"></param>
    /// <returns>Feedbacks list</returns>
    /// <remarks>
    /// If the hotel with hotelId does not exist, the response code will be 404. <br /> <br />
    /// </remarks>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If query parameters are invalid</response>
    /// <response code="404">If the item does not exist</response>
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