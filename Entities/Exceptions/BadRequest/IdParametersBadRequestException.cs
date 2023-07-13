namespace Entities.Exceptions.BadRequest;

public class IdParametersBadRequestException : BadRequestException
{
    public IdParametersBadRequestException()
        : base("Parameter ids is null")
    { }
}