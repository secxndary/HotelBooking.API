namespace Shared.DataTransferObjects.InputDtos;

public record RoomForCreationDto
(
    int Price,
    int Quantity,
    int SleepingPlaces,
    Guid RoomTypeId
);