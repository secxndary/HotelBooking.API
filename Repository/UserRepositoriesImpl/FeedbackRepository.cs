using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository.UserRepositoriesImpl;

public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<IEnumerable<Feedback>> GetFeedbacksForHotelAsync(Guid hotelId, bool trackChanges) =>
        await FindByCondition(f => 
            f.Reservation.Room.HotelId.Equals(hotelId), trackChanges)
        .ToListAsync();

    public async Task<IEnumerable<Feedback>> GetFeedbacksForRoomAsync(Guid roomId, bool trackChanges) =>
        await FindByCondition(f =>
            f.Reservation.RoomId.Equals(roomId), trackChanges)
        .ToListAsync();

    public async Task<IEnumerable<Feedback>> GetFeedbacksForReservationAsync(Guid reservationId, bool trackChanges) =>
        await FindByCondition(f =>
            f.ReservationId.Equals(reservationId), trackChanges)
        .ToListAsync();

    public async Task<Feedback?> GetFeedbackAsync(Guid id, bool trackChanges) =>
        await FindByCondition(f => f.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateFeedbackForReservation(Guid reservationId, Feedback feedback)
    {
        feedback.ReservationId = reservationId;
        Create(feedback);
    }

    public void DeleteFeedback(Feedback feedback) =>
        Delete(feedback);
}