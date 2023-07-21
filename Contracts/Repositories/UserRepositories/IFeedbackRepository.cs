using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IFeedbackRepository
{
    Task<IEnumerable<Feedback>> GetFeedbacksForHotelAsync(Guid hotelId, bool trackChanges);
    Task<IEnumerable<Feedback>> GetFeedbacksForRoomAsync(Guid roomId, bool trackChanges);
    Task<IEnumerable<Feedback>> GetFeedbacksForReservationAsync(Guid reservationId, bool trackChanges);
    Task<Feedback?> GetFeedbackAsync(Guid id, bool trackChanges);
    void CreateFeedbackForReservation(Guid reservationId, Feedback feedback);
    void DeleteFeedback(Feedback feedback);
}