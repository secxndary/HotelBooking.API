namespace Shared.DataTransferObjects.UpdateDtos;

public record RoomForUpdateDto
(
    int Price,
    int Quantity,
    int SleepingPlaces,
    Guid RoomTypeId
);