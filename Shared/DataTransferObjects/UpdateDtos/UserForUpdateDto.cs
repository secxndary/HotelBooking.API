namespace Shared.DataTransferObjects.UpdateDtos;

public record UserForUpdateDto
(
    string FirstName,
    string LastName,
    string Email,
    string Password,
    Guid RoleId
);