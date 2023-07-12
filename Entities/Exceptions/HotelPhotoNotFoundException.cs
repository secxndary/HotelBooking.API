namespace Entities.Exceptions;

public class HotelPhotoNotFoundException : NotFoundException
{
    public HotelPhotoNotFoundException(Guid hotelPhotoId)
        : base($"Hotel photo with id: {hotelPhotoId} doesn't exist in the database.")
    { }
}