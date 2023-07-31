using Microsoft.AspNetCore.Identity;
namespace Entities.Models;

public class UserIdentity : IdentityUser
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
}