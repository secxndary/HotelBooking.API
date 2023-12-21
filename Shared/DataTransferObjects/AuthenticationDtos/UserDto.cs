using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.AuthenticationDtos;

public record UserDto
{
    public string Id { get; init; }
    
    public string? FirstName { get; init; }

    public string? LastName { get; init; }

    [Required(ErrorMessage = "Введите имя пользователя")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Введите пароль")]
    public string? Password { get; init; }
    
    public string? Email { get; init; }
    
    public string? PhoneNumber { get; init; }
    
    public ICollection<string>? Roles { get; set; }
}