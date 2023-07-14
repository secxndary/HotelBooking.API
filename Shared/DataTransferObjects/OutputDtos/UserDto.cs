namespace Shared.DataTransferObjects.OutputDtos;

public record UserDto
{
    public Guid Id { get; init; }
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    public string? Email { get; init; }
    public string? Password { get; init; }
    public Guid? RoleId { get; init; }
}