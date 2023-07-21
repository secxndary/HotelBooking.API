using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IReservationService
{
    Task<IEnumerable<ReservationDto>> GetReservationsAsync(Guid roomId, bool trackChanges);
    Task<ReservationDto> GetReservationAsync(Guid roomId, Guid id, bool trackChanges);
    Task<ReservationDto> CreateReservationForRoomAsync(Guid roomId, ReservationForCreationDto reservation, bool trackChanges);
    Task UpdateReservationForRoomAsync(Guid roomId, Guid id, ReservationForUpdateDto reservation, bool trackChanges);
    Task<(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity)> GetReservationForPatchAsync
        (Guid roomId, Guid id, bool roomTrackChanges, bool reservationTrackChanges);
    Task SaveChangesForPatchAsync(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity);
    Task DeleteReservationForRoomAsync(Guid roomId, Guid id, bool trackChanges);
}