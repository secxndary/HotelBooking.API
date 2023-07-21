using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models;

public class User
{
    public Guid Id { get; set; }

    [MaxLength(100, ErrorMessage = "Maximum length for the FirstName is 100 characters.")]
    public string? FirstName { get; set; }

    [MaxLength(100, ErrorMessage = "Maximum length for the LastName is 100 characters.")]
    public string? LastName { get; set; }

    [EmailAddress]
    [Required(ErrorMessage = "Email is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Email is 50 characters.")]
    public string? Email { get; set; }

    [Required(ErrorMessage = "Password is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Password is 50 characters.")]
    public string? Password { get; set; }

    [ForeignKey(nameof(Role))]
    public Guid RoleId { get; set; }
    public Role? Role { get; set; }

    public ICollection<Reservation>? Reservations { get; set; }
}
