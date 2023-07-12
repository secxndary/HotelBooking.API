namespace Entities.Exceptions;

public class FeedbackNotFoundException : NotFoundException
{
    public FeedbackNotFoundException(Guid userId)
        : base($"Feedback with id: {userId} doesn't exist in the database.")
    { }
}