namespace Shared.DataTransferObjects;

public record HotelDto
(
    Guid Id,
    string Name,
    string Description,
    int Stars
);