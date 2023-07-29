using Entities.Models;
namespace Repository.Extentsions;

public static class FeedbackRepositoryExtensions
{
    public static IQueryable<Feedback> Search(this IQueryable<Feedback> feedbacks, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return feedbacks;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        var feedbacksWithSearchTermInTextPositive = feedbacks
            .Where(f => f.TextPositive.ToLower().Contains(lowerCaseTerm));

        var feedbacksWithSearchTermInTextNegative = feedbacks
            .Where(f => 
                !f.TextPositive.ToLower().Contains(lowerCaseTerm) &&
                f.TextNegative.ToLower().Contains(lowerCaseTerm));

        var result = feedbacksWithSearchTermInTextPositive
            .Union(feedbacksWithSearchTermInTextNegative);

        return result;
    }
}
