namespace Entities.Exceptions.BadRequest;

public class RoomCollectionBadRequest : BadRequestException
{
    public RoomCollectionBadRequest()
        : base("Room collection sent from a client is null.")
    { }
}