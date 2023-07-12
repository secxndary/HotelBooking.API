namespace Shared.DataTransferObjects;

public record RoomPhotoDto
{
    public Guid Id { get; init; }
    public string? Path { get; init; }
}