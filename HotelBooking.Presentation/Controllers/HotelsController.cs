using System.Text.Json;
using Entities.ErrorModel;
using Entities.Exceptions.BadRequest.Filtering;
using HotelBooking.Presentation.Filters.ActionFilters;
using HotelBooking.Presentation.ModelBinders;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels")]
[ApiController]
[Authorize]
public class HotelsController : ControllerBase
{
    private readonly IServiceManager _service;
    public HotelsController(IServiceManager service) => _service = service;


    /// <summary>
    /// Gets the list of all hotels
    /// </summary>
    /// <param name="hotelParameters"></param>
    /// <returns>Hotels list</returns>
    /// <response code="200">Returns list of items</response>
    /// <response code="400">If </response>
    [ProducesResponseType(typeof(IEnumerable<HotelDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [HttpGet(Name = "GetHotels")]
    [HttpHead]
    public async Task<IActionResult> GetHotels([FromQuery] HotelParameters hotelParameters)
    {
        var (hotels, metadata)= await _service.HotelService.GetAllHotelsAsync(hotelParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
        return Ok(hotels);
    }

    /// <summary>
    /// Gets the collection of hotels by ids
    /// </summary>
    /// <param name="ids"></param>
    /// <returns>Hotels list</returns>
    /// <response code="200">Returns list of items</response>
    [ProducesResponseType(typeof(IEnumerable<HotelDto>), 200)]
    [HttpGet("collection/({ids})", Name = "HotelCollection")]
    public async Task<IActionResult> GetHotelCollection(
        [ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var hotels = await _service.HotelService.GetByIdsAsync(ids);
        return Ok(hotels);
    }

    /// <summary>
    /// Gets hotel by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>Hotel</returns>
    /// <response code="200">Returns item</response>
    /// <response code="404">If this item does not exist</response>
    [ProducesResponseType(typeof(HotelDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 404)]
    [HttpGet("{id:guid}", Name = "HotelById")]
    public async Task<IActionResult> GetHotel(Guid id)
    {
        var hotel = await _service.HotelService.GetHotelAsync(id);
        return Ok(hotel);
    }

    /// <summary>
    /// Creates a newly created hotel
    /// </summary>
    /// <param name="hotel"></param>
    /// <returns>A newly created hotel</returns>
    /// <response code="201">Returns a newly created item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [ProducesResponseType(typeof(HotelDto), 201)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    [HttpPost(Name = "CreateHotel")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateHotel([FromBody] HotelForCreationDto hotel)
    {
        var createdHotel = await _service.HotelService.CreateHotelAsync(hotel);
        return CreatedAtRoute("HotelById", new { id = createdHotel.Id }, createdHotel);
    }

    /// <summary>
    /// Creates collection of hotels
    /// </summary>
    /// <param name="hotelCollection"></param>
    /// <returns>Created collection of hotels</returns>
    /// <response code="200">Returns a newly created list of items</response>
    /// <response code="400">If the collection is null</response>
    /// <response code="422">If the model is invalid</response>
    [ProducesResponseType(typeof(IEnumerable<HotelDto>), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    [HttpPost("collection")]
    [Authorize(Roles = "Admin, HotelOwner")]
    public async Task<IActionResult> CreateHotelCollection(
        [FromBody] IEnumerable<HotelForCreationDto> hotelCollection)
    {
        var (hotels, ids) = await _service.HotelService.CreateHotelCollectionAsync(hotelCollection);
        return CreatedAtRoute("HotelCollection", new { ids }, hotels);
    }

    /// <summary>
    /// Updates hotel by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="hotel"></param>
    /// <returns>Updated hotel</returns>
    /// <response code="200">Returns updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [ProducesResponseType(typeof(HotelDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    [HttpPut("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] HotelForUpdateDto hotel)
    {
        var updatedHotel = await _service.HotelService.UpdateHotelAsync(id, hotel);
        return Ok(updatedHotel);
    }

    /// <summary>
    /// Partially updates hotel by id
    /// </summary>
    /// <param name="id"></param>
    /// <param name="patchDoc"></param>
    /// <returns>Updated hotel</returns>
    /// <response code="200">Returns updated item</response>
    /// <response code="400">If the item is null</response>
    /// <response code="422">If the model is invalid</response>
    [ProducesResponseType(typeof(HotelDto), 200)]
    [ProducesResponseType(typeof(ErrorDetails), 400)]
    [ProducesResponseType(typeof(ErrorDetails), 422)]
    [HttpPatch("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    public async Task<IActionResult> PartiallyUpdateHotel(Guid id,
        [FromBody] JsonPatchDocument<HotelForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (hotelToPatch, hotelEntity) = await _service.HotelService.GetHotelForPatchAsync(id);
        patchDoc.ApplyTo(hotelToPatch);

        TryValidateModel(hotelToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedHotel = await _service.HotelService.SaveChangesForPatchAsync(hotelToPatch, hotelEntity);
        return Ok(updatedHotel);
    }

    /// <summary>
    /// Deletes hotel by id
    /// </summary>
    /// <param name="id"></param>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    /// <response code="404">If the item does not exist</response>
    [ProducesResponseType(204)]
    [ProducesResponseType(404)]
    [HttpDelete("{id:guid}")]
    [Authorize(Roles = "Admin, HotelOwner")]
    public async Task<IActionResult> DeleteHotel(Guid id)
    {
        await _service.HotelService.DeleteHotelAsync(id);
        return NoContent();
    }

    /// <summary>
    /// Shows possible request methods
    /// </summary>
    /// <returns>No content</returns>
    /// <response code="204">Returnes No content</response>
    [ProducesResponseType(204)]
    [HttpOptions]
    public IActionResult GetHotelsOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}