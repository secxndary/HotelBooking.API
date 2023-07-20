using Shared.DataTransferObjects.InputDtos;
namespace Shared.DataTransferObjects.UpdateDtos;

public record HotelForUpdateDto
(
    string Name,
    string Description,
    int Stars,
    IEnumerable<RoomForCreationDto> Rooms
);