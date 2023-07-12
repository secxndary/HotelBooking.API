﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/hotels/{hotelId}/rooms")]
[ApiController]
public class RoomsController : ControllerBase
{
    private readonly IServiceManager _service;
    public RoomsController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetRoomsForHotel(Guid hotelId)
    {
        var rooms = _service.RoomService.GetRooms(hotelId, trackChanges: false);
        return Ok(rooms);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRoomForHotel(Guid hotelId, Guid id)
    {
        var room = _service.RoomService.GetRoom(hotelId, id, trackChanges: false);
        return Ok(room);
    }
}