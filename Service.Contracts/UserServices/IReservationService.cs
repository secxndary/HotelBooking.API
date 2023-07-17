using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
namespace Service.Contracts.UserServices;

public interface IReservationService
{
    IEnumerable<ReservationDto> GetReservations(Guid roomId, bool trackChanges);
    ReservationDto GetReservation(Guid roomId, Guid id, bool trackChanges);
    ReservationDto CreateReservationForRoom(Guid roomId, ReservationForCreationDto reservation, bool trackChanges);
    void DeleteReservationForRoom(Guid roomId, Guid id, bool trackChanges);
}