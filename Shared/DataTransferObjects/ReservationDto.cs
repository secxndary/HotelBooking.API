namespace Shared.DataTransferObjects;

public record Dto
{
    public Guid Id { get; init; }
    public DateTime DateEntry { get; init; }
    public DateTime DateExit { get; init; }

}