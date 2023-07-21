using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository.UserRepositoriesImpl;

public class ReservationRepository : RepositoryBase<Reservation>, IReservationRepository
{
    public ReservationRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<IEnumerable<Reservation>> GetReservationsAsync(Guid roomId, bool trackChanges) =>
        await FindByCondition(r => r.RoomId.Equals(roomId), trackChanges)
        .ToListAsync();

    public async Task<Reservation?> GetReservationAsync(Guid roomId, Guid id, bool trackChanges) =>
        await FindByCondition(r =>
            r.RoomId.Equals(roomId) &&
            r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<Reservation?> GetReservationAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateReservationForRoom(Guid roomId, Reservation reservation)
    {
        reservation.RoomId = roomId;
        Create(reservation);
    }

    public void DeleteReservation(Reservation reservation) =>
        Delete(reservation);
}