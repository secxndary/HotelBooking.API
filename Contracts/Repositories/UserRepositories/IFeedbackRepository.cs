using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IFeedbackRepository
{
    IEnumerable<Feedback> GetFeedbacksForHotel(Guid hotelId, bool trackChanges);
    IEnumerable<Feedback> GetFeedbacksForRoom(Guid roomId, bool trackChanges);
    IEnumerable<Feedback> GetFeedbacksForReservation(Guid reservationId, bool trackChanges);
    Feedback? GetFeedbackForHotel(Guid hotelId, Guid id, bool trackChanges);
    Feedback? GetFeedbackForRoom(Guid roomId, Guid id, bool trackChanges);
    Feedback? GetFeedbackForReservation(Guid reservationId, Guid id, bool trackChanges);
    Feedback? GetFeedback(Guid id, bool trackChanges);
    void DeleteFeedback(Feedback feedback);
}