using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.InputDtos;

public record RoomForCreationDto
{
    [Required(ErrorMessage = "Price is a required field.")]
    public int Price { get; init; }

    [Required(ErrorMessage = "Quantity is a required field.")]
    public int Quantity { get; init; }

    [Required(ErrorMessage = "SleepingPlaces is a required field.")]
    [Range(1, 8)]
    public int SleepingPlaces { get; init; }

    [Required(ErrorMessage = "RoomTypeId is a required field.")]
    public Guid RoomTypeId { get; init; }
}