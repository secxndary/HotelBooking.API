using System.Text.Json;
using HotelBooking.Presentation.Filters.ActionFilters;
using HotelBooking.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly IServiceManager _service;
    public HotelsController(IServiceManager service) => _service = service;


    [HttpGet]
    [HttpHead]
    public async Task<IActionResult> GetHotels([FromQuery] HotelParameters hotelParameters)
    {
        var (hotels, metadata)= await _service.HotelService.GetAllHotelsAsync(hotelParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metadata));
        return Ok(hotels);
    }

    [HttpGet("collection/({ids})", Name = "HotelCollection")]
    public async Task<IActionResult> GetHotelCollection(
        [ModelBinder(typeof(ArrayModelBinder))] IEnumerable<Guid> ids)
    {
        var hotels = await _service.HotelService.GetByIdsAsync(ids);
        return Ok(hotels);
    }

    [HttpGet("{id:guid}", Name = "HotelById")]
    public async Task<IActionResult> GetHotel(Guid id)
    {
        var hotel = await _service.HotelService.GetHotelAsync(id);
        return Ok(hotel);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateHotel([FromBody] HotelForCreationDto hotel)
    {
        var createdHotel = await _service.HotelService.CreateHotelAsync(hotel);
        return CreatedAtRoute("HotelById", new { id = createdHotel.Id }, createdHotel);
    }

    [HttpPost("collection")]
    public async Task<IActionResult> CreateHotelCollection(
        [FromBody] IEnumerable<HotelForCreationDto> hotelCollection)
    {
        var (hotels, ids) = await _service.HotelService.CreateHotelCollectionAsync(hotelCollection);
        return CreatedAtRoute("HotelCollection", new { ids }, hotels);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] HotelForUpdateDto hotel)
    {
        var updatedHotel = await _service.HotelService.UpdateHotelAsync(id, hotel);
        return Ok(updatedHotel);
    }

    [HttpPatch("{id:guid}")]
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

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteHotel(Guid id)
    {
        await _service.HotelService.DeleteHotelAsync(id);
        return NoContent();
    }

    [HttpOptions]
    public IActionResult GetHotelsOptions()
    {
        Response.Headers.Add("Allow", "GET, OPTIONS, POST");
        return Ok();
    }
}