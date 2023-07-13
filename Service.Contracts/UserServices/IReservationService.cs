using Shared.DataTransferObjects;
namespace Service.Contracts.UserServices;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetReservations(Guid roomId, bool trackChanges);
    ReservationDto GetReservation(Guid roomId, Guid id, bool trackChanges);
    void DeleteReservationForRoom(Guid roomId, Guid id, bool trackChanges);
}