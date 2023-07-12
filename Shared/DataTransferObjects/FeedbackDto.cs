namespace Shared.DataTransferObjects;

public record FeedbackDto
{
    public Guid Id { get; init; }
    public string? TextPositive { get; init; }
    public string? TextNegative { get; init; }
}