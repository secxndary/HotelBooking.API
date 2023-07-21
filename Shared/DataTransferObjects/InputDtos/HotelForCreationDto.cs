using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.InputDtos;

public record HotelForCreationDto
{
    [Required(ErrorMessage = "Name is a required field.")]
    [MaxLength(50, ErrorMessage = "Maximum length for the Name is 50 characters.")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Description is a required field.")]
    [MaxLength(3000, ErrorMessage = "Maximum length for the Description is 3000 characters.")]
    public string? Description { get; init; }

    [Required(ErrorMessage = "Stars is a required field.")]
    public int Stars { get; init; }

    public IEnumerable<RoomForCreationDto>? Rooms { get; init; }
}