namespace Entities.Exceptions.BadRequest;

public class CollectionByIdsBadRequestException : BadRequestException
{
    public CollectionByIdsBadRequestException()
        : base("Collection count mismatch comparing to ids.")
    { }
}