namespace Entities.Exceptions.BadRequest;

public class HotelPhotoCollectionBadRequest : BadRequestException
{
    public HotelPhotoCollectionBadRequest()
        : base("Hotel photo collection sent from a client is null.")
    { }
}