namespace Shared.DataTransferObjects;

public record HotelPhotoDto
{
    public Guid Id { get; init; }
    public string? Path { get; init; }
}