﻿using Microsoft.AspNetCore.Identity;
namespace Entities.Models;

public class UserIdentity : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
    public bool HotelOwnerConfirmedByAdmin { get; set; } = false;
    public bool HotelOwnerDeclinedByAdmin { get; set; } = false;
}