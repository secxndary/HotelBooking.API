using HotelBooking.Presentation.ModelBinders;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels")]
[ApiController]
public class HotelsController : ControllerBase
{
    private readonly IServiceManager _service;
    public HotelsController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetHotels()
    {
        var hotels = _service.HotelService.GetAllHotels(trackChanges: false);
        return Ok(hotels);
    }

    [HttpGet("collection/({ids})", Name = "HotelCollection")]
    public IActionResult GetHotelCollection(
        [ModelBinder(typeof(ArrayModelBinder))]
        IEnumerable<Guid> ids)
    {
        var hotels = _service.HotelService.GetByIds(ids, trackChanges: false);
        return Ok(hotels);
    }

    [HttpGet("{id:guid}", Name = "HotelById")]
    public IActionResult GetHotel(Guid id)
    {
        var hotel = _service.HotelService.GetHotel(id, trackChanges: false);
        return Ok(hotel);
    }

    [HttpPost]
    public IActionResult CreateHotel([FromBody] HotelForCreationDto hotel)
    {
        if (hotel is null)
            return BadRequest("HotelForCreationDto object is null");

        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var createdHotel = _service.HotelService.CreateHotel(hotel);
        return CreatedAtRoute("HotelById", new { id = createdHotel.Id }, createdHotel);
    }

    [HttpPost("collection")]
    public IActionResult CreateHotelCollection(
        [FromBody] 
        IEnumerable<HotelForCreationDto> hotelCollection)
    {
        var result = _service.HotelService.CreateHotelCollection(hotelCollection);
        return CreatedAtRoute("HotelCollection", new { result.ids }, result.hotels);
    }

    [HttpPut("{id:guid}")]
    public IActionResult UpdateHotel(Guid id, [FromBody] HotelForUpdateDto hotel)
    {
        if (hotel is null)
            return BadRequest("HotelForUpdateDto object is null");
        _service.HotelService.UpdateHotel(id, hotel, trackChanges: true);
        return NoContent();
    }

    [HttpPatch("{id:guid}")]
    public IActionResult PartiallyUpdateHotel(
        Guid id,
        [FromBody] JsonPatchDocument<HotelForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (hotelToPatch, hotelEntity) = _service.HotelService.GetHotelForPatch(id, trackChanges: true);
        patchDoc.ApplyTo(hotelToPatch);

        _service.HotelService.SaveChangesForPatch(hotelToPatch, hotelEntity);
        return NoContent();
    }

    [HttpDelete("{id:guid}")]
    public IActionResult DeleteHotel(Guid id)
    {
        _service.HotelService.DeleteHotel(id, trackChanges: false);
        return NoContent();
    }
}