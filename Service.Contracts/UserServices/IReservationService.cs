using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetReservations(Guid roomId, bool trackChanges);
    ReservationDto GetReservation(Guid roomId, Guid id, bool trackChanges);
    ReservationDto CreateReservationForRoom(Guid roomId, ReservationForCreationDto reservation, bool trackChanges);
    void UpdateReservationForRoom(Guid roomId, Guid id, ReservationForUpdateDto reservation, bool trackChanges);
    (ReservationForUpdateDto reservationToPatch, Reservation reservationEntity) GetReservationForPatch
        (Guid roomId, Guid id, bool roomTrackChanges, bool reservationTrackChanges);
    void SaveChangesForPatch(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity);
    void DeleteReservationForRoom(Guid roomId, Guid id, bool trackChanges);
}