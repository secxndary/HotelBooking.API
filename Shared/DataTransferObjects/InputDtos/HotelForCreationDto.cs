namespace Shared.DataTransferObjects.InputDtos;

public record HotelForCreationDto
(
    string Name,
    string Description,
    int Stars,
    IEnumerable<RoomForCreationDto> Rooms
);