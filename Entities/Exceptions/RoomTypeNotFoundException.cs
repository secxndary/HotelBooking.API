namespace Entities.Exceptions;

public class RoomTypeNotFoundException : NotFoundException
{
    public RoomTypeNotFoundException(Guid userId)
        : base($"Room type with id: {userId} doesn't exist in the database.")
    { }
}