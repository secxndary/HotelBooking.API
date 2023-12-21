using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.AuthenticationDtos;

public record  UserForAuthenticationDto
{
    [Required(ErrorMessage = "Введите имя пользователя")]
    public string? UserName { get; init; }

    [Required(ErrorMessage = "Введите пароль")]
    public string? Password { get; init; }
}
