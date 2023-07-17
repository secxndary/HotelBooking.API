namespace Entities.Exceptions.BadRequest;

public class RoomPhotoCollectionBadRequest : BadRequestException
{
    public RoomPhotoCollectionBadRequest()
        : base("Room photo collection sent from a client is null.")
    { }
}