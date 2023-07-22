using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IReservationService
{
    Task<IEnumerable<ReservationDto>> GetReservationsAsync(Guid roomId);
    Task<ReservationDto> GetReservationAsync(Guid roomId, Guid id);
    Task<ReservationDto> CreateReservationForRoomAsync(Guid roomId, ReservationForCreationDto reservation);
    Task<ReservationDto> UpdateReservationForRoomAsync(Guid roomId, Guid id, ReservationForUpdateDto reservation);
    Task<(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity)> GetReservationForPatchAsync
        (Guid roomId, Guid id);
    Task<ReservationDto> SaveChangesForPatchAsync(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity);
    Task DeleteReservationForRoomAsync(Guid roomId, Guid id);
}