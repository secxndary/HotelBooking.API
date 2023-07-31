using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IFeedbackRepository
{
    Task<PagedList<Feedback>> GetFeedbacksForHotelAsync(Guid hotelId, FeedbackParameters feedbackParameters, bool trackChanges);
    Task<IEnumerable<Feedback>> GetFeedbacksForRoomAsync(Guid roomId, bool trackChanges);
    Task<IEnumerable<Feedback>> GetFeedbacksForReservationAsync(Guid reservationId, bool trackChanges);
    Task<Feedback?> GetFeedbackAsync(Guid id, bool trackChanges);
    void CreateFeedback(Feedback feedback);
    void DeleteFeedback(Feedback feedback);
}