using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IFeedbackRepository
{
    IEnumerable<Feedback> GetFeedbacksForHotel(Guid hotelId, bool trackChanges);
    IEnumerable<Feedback> GetFeedbacksForRoom(Guid roomId, bool trackChanges);
    IEnumerable<Feedback> GetFeedbacksForReservation(Guid reservationId, bool trackChanges);
    Feedback? GetFeedback(Guid id, bool trackChanges);
    void CreateFeedbackForReservation(Guid reservationId, Feedback feedback);
    void DeleteFeedback(Feedback feedback);
}