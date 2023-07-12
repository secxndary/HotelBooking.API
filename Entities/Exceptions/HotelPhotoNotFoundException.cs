namespace Entities.Exceptions;

public class HotelPhotoNotFoundException : NotFoundException
{
    public HotelPhotoNotFoundException(Guid userId)
        : base($"Hotel photo with id: {userId} doesn't exist in the database.")
    { }
}