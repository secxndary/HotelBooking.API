namespace Entities.Exceptions.BadRequest;

public class MaxSleepingPlacesRangeBadRequestException : BadRequestException
{
    public MaxSleepingPlacesRangeBadRequestException()
        : base("Maximun amount of Sleeping places can't be less than the minimum amount.")
    { }
}
