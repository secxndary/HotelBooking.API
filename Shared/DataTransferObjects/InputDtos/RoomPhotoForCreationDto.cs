using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.InputDtos;

public record RoomPhotoForCreationDto
{
    [Required(ErrorMessage = "Path is a required field.")]
    public string? Path { get; init; }
}