using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public abstract record ReservationForManipulationDto
{
    [Required(ErrorMessage = "Введите дату заезда")]
    public DateTime DateEntry { get; init; }

    [Required(ErrorMessage = "Введите дату выезда")]
    public DateTime DateExit { get; init; }

    [Required(ErrorMessage = "Введите идентификатор пользователя")]
    public string? UserId { get; init; }
}