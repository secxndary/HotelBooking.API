namespace Entities.Exceptions;

public class RoomNotFoundException : NotFoundException
{
    public RoomNotFoundException(Guid roomId)
        : base($"Room with id: {roomId} doesn't exist in the database.")
    { }
}
