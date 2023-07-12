using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IFeedbackRepository
{
    IEnumerable<Feedback> GetFeedbacks(Guid hotelId, bool trackChanges);
    Feedback GetFeedback(Guid hotelId, Guid id, bool trackChanges);
}