namespace Shared.DataTransferObjects.InputDtos;

public record UserForCreationDto
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    Guid RoleId
);