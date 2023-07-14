using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<Feedback> GetFeedbacksForHotel(Guid hotelId, bool trackChanges) =>
        FindByCondition(f => 
            f.Reservation.Room.HotelId.Equals(hotelId), trackChanges)
        .ToList();

    public IEnumerable<Feedback> GetFeedbacksForRoom(Guid roomId, bool trackChanges) =>
        FindByCondition(f =>
            f.Reservation.RoomId.Equals(roomId), trackChanges)
        .ToList();

    public IEnumerable<Feedback> GetFeedbacksForReservation(Guid reservationId, bool trackChanges) =>
        FindByCondition(f =>
            f.ReservationId.Equals(reservationId), trackChanges)
        .ToList();

    public Feedback? GetFeedbackForHotel(Guid hotelId, Guid id, bool trackChanges) =>
        FindByCondition(f =>
            f.Reservation.Room.HotelId.Equals(hotelId) &&
            f.Id.Equals(id), trackChanges)
        .SingleOrDefault();
    
    public Feedback? GetFeedbackForRoom(Guid roomId, Guid id, bool trackChanges) =>
            FindByCondition(f =>
                f.Reservation.RoomId.Equals(roomId) &&
                f.Id.Equals(id), trackChanges)
            .SingleOrDefault();

    public Feedback? GetFeedbackForReservation(Guid reservationId, Guid id, bool trackChanges) =>
            FindByCondition(f =>
                f.ReservationId.Equals(reservationId) &&
                f.Id.Equals(id), trackChanges)
            .SingleOrDefault();

    public Feedback? GetFeedback(Guid id, bool trackChanges) =>
        FindByCondition(f => f.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void DeleteFeedback(Feedback feedback) =>
        Delete(feedback);
}