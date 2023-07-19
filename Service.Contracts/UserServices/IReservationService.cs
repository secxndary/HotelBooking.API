using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetReservations(Guid roomId, bool trackChanges);
    ReservationDto GetReservation(Guid roomId, Guid id, bool trackChanges);
    ReservationDto CreateReservationForRoom(Guid roomId, ReservationForCreationDto reservation, bool trackChanges);
    void UpdateReservationForRoom(Guid roomId, Guid id, ReservationForUpdateDto reservationForUpdate, bool trackChanges);
    void DeleteReservationForRoom(Guid roomId, Guid id, bool trackChanges);
}