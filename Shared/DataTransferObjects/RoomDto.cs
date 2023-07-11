namespace Shared.DataTransferObjects;

public record RoomDto
(
    Guid Id,
    int Price,
    int Quantity,
    int SleepingPlaces
);