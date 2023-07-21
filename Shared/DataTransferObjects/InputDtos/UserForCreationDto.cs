using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.InputDtos;

public record UserForCreationDto
{ 
    [MaxLength(100, ErrorMessage = "Maximum length for the FirstName is 100 characters.")]
    public string? FirstName { get; init; }

    [MaxLength(100, ErrorMessage = "Maximum length for the LastName is 100 characters.")]
    public string? LastName { get; init; }

    [RegularExpression("\\w+@\\w+.\\w+", ErrorMessage = "Email should have correct name and domain.")]
    [Required(ErrorMessage = "Email is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Email is 50 characters.")]
    public string? Email { get; init; }

    [Required(ErrorMessage = "Password is a required field.")]
    public string? Password { get; init; }

    [Required(ErrorMessage = "RoleId is a required field.")]
    public Guid RoleId { get; init; }
}