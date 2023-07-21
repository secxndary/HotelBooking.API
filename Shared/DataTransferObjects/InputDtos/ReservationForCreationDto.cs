using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.InputDtos;

public record ReservationForCreationDto
{
    [Required(ErrorMessage = "DateEntry is a required field.")]
    public DateTime DateEntry { get; init; }

    [Required(ErrorMessage = "DateExit is a required field.")]
    public DateTime DateExit { get; init; }

    [Required(ErrorMessage = "UserId is a required field.")]
    public Guid UserId { get; init; }
}