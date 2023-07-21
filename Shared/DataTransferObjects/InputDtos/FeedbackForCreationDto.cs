namespace Shared.DataTransferObjects.InputDtos;

public record FeedbackForCreationDto
{
    public string? TextPositive { get; init; }
    public string? TextNegative { get; init; }
    public Guid ReservationId { get; init; }
}