namespace Shared.DataTransferObjects.InputDtos;

public record ReservationForCreationDto
(
    DateTime DateEntry,
    DateTime DateExit,
    Guid UserId
);