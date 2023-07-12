namespace Entities.Exceptions;

public class RoomTypeNotFoundException : NotFoundException
{
    public RoomTypeNotFoundException(Guid roomTypeId)
        : base($"Room type with id: {roomTypeId} doesn't exist in the database.")
    { }
}