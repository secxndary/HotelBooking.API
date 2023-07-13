using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
{
    public ReservationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<Reservation> GetReservations(Guid roomId, bool trackChanges) =>
        FindByCondition(r => r.RoomId.Equals(roomId), trackChanges)
        .ToList();

    public Reservation? GetReservation(Guid roomId, Guid id, bool trackChanges) =>
        FindByCondition(r =>
            r.RoomId.Equals(roomId) &&
            r.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void DeleteReservation(Reservation reservation) =>
        Delete(reservation);
}