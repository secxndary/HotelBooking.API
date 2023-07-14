using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IReservationRepository
{
    IEnumerable<Reservation> GetReservations(Guid roomId, bool trackChanges);
    Reservation? GetReservation(Guid roomId, Guid id, bool trackChanges);
    Reservation? GetReservation(Guid id, bool trackChanges);
    void DeleteReservation(Reservation reservation);
}