using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoomTypeService
{
    IEnumerable<RoomTypeDto> GetAllRoomTypes(bool trackChanges);
    RoomTypeDto GetRoomType(Guid id, bool trackChanges);
    RoomTypeDto CreateRoomType(RoomTypeForCreationDto roomType);
    void UpdateRoomType(Guid id, RoomTypeForUpdateDto roomType, bool trackChanges);
    void DeleteRoomType(Guid id, bool trackChanges);
}