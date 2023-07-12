namespace Entities.Exceptions;

public class RoomPhotoNotFoundException : NotFoundException
{
    public RoomPhotoNotFoundException(Guid userId)
        : base($"Room photo with id: {userId} doesn't exist in the database.")
    { }
}