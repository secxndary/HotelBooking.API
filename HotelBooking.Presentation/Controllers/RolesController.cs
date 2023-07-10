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
        try
        {
            var roles = _service.RoleService.GetAllRoles(trackChanges: false);
            return Ok(roles);
        }
        catch
        { 
            return StatusCode(500, "Internal server error");
        }
    }
}