using System.Text.Json;
using HotelBooking.Presentation.Filters.ActionFilters;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures.UserParameters;
namespace HotelBooking.Presentation.Controllers;

[Route("api/roomTypes")]
[ApiController]
public class RoomTypesController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomTypesController(IServiceManager service) => _service = service;


    [HttpGet]
    public async Task<IActionResult> GetRoomTypes([FromQuery] RoomTypeParameters roomTypeParameters)
    {
        var (roomTypes, metaData) = await _service.RoomTypeService.GetAllRoomTypesAsync(roomTypeParameters);
        Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(metaData));
        return Ok(roomTypes);
    }

    [HttpGet("{id:guid}", Name = "RoomTypeById")]
    public async Task<IActionResult> GetRoomType(Guid id)
    {
        var roomType = await _service.RoomTypeService.GetRoomTypeAsync(id);
        return Ok(roomType);
    }

    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> CreateRoomType([FromBody] RoomTypeForCreationDto roomType)
    {
        var createdRoomType = await _service.RoomTypeService.CreateRoomTypeAsync(roomType);
        return CreatedAtRoute("RoomTypeById", new { id = createdRoomType.Id }, createdRoomType);
    }

    [HttpPut("{id:guid}")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> UpdateRoomType(Guid id, [FromBody] RoomTypeForUpdateDto roomType)
    {
        var updatedRoomType = await _service.RoomTypeService.UpdateRoomTypeAsync(id, roomType);
        return Ok(updatedRoomType);
    }

    [HttpPatch("{id:guid}")]
    public async Task<IActionResult> PartiallyUpdateRoomType(Guid id,
        [FromBody] JsonPatchDocument<RoomTypeForUpdateDto> patchDoc)
    {
        if (patchDoc is null)
            return BadRequest("patchDoc object is null");

        var (roomTypeToPatch, roomTypeEntity) = await _service.RoomTypeService.GetRoomTypeForPatchAsync(id);
        patchDoc.ApplyTo(roomTypeToPatch);

        TryValidateModel(roomTypeToPatch);
        if (!ModelState.IsValid)
            return UnprocessableEntity(ModelState);

        var updatedRoomType = await _service.RoomTypeService.SaveChangesForPatchAsync(roomTypeToPatch, roomTypeEntity);
        return Ok(updatedRoomType);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteRoomType(Guid id)
    {
        await _service.RoomTypeService.DeleteRoomTypeAsync(id);
        return NoContent();
    }
}