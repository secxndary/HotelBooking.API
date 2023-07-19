namespace Shared.DataTransferObjects.UpdateDtos;

public record ReservationForUpdateDto
(
    DateTime DateEntry,
    DateTime DateExit,
    Guid UserId
);