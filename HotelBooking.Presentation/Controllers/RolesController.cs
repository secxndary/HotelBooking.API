﻿using Microsoft.AspNetCore.Mvc;
using Service.Contracts;
namespace HotelBooking.Presentation.Controllers;

[Route("api/roles")]
[ApiController]
public class RolesController : ControllerBase
{
    private readonly IServiceManager _service;
    public RolesController(IServiceManager service) => _service = service;


    [HttpGet]
    public IActionResult GetRoles()
    {
        var roles = _service.RoleService.GetAllRoles(trackChanges: false);
        return Ok(roles);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetRole(Guid id)
    {
        var role = _service.RoleService.GetRole(id, trackChanges: false);
        return Ok(role);
    }
}