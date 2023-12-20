using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IReservationRepository
{
    Task<PagedList<Reservation>> GetAllReservationsAsync(ReservationlParameters reservationlParameters, bool trackChanges);
    Task<PagedList<Reservation>> GetReservationsByRoomAsync(Guid roomId, ReservationlParameters reservationlParameters, bool trackChanges);
    Task<PagedList<Reservation>> GetReservationsByUserAsync(string userId, ReservationlParameters reservationlParameters, bool trackChanges);
    Task<Reservation?> GetReservationAsync(Guid roomId, Guid id, bool trackChanges);
    Task<Reservation?> GetReservationAsync(Guid id, bool trackChanges);
    void CreateReservationForRoom(Guid roomId,  Reservation reservation);
    void DeleteReservation(Reservation reservation);
}