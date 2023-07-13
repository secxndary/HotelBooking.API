using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class FeedbackRepository : RepositoryBase<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<Feedback> GetFeedbacks(Guid hotelId, bool trackChanges) =>
        FindByCondition(f => 
            f.Reservation.Room.HotelId.Equals(hotelId), trackChanges)
        .ToList();

    public Feedback? GetFeedback(Guid hotelId, Guid id, bool trackChanges) =>
        FindByCondition(f => 
            f.Reservation.Room.HotelId.Equals(hotelId) &&
            f.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void DeleteFeedback(Feedback feedback) =>
        Delete(feedback);
}