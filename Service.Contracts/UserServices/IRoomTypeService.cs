using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoomTypeService
{
    Task<IEnumerable<RoomTypeDto>> GetAllRoomTypesAsync(bool trackChanges);
    Task<RoomTypeDto> GetRoomTypeAsync(Guid id, bool trackChanges);
    Task<RoomTypeDto> CreateRoomTypeAsync(RoomTypeForCreationDto roomType);
    Task UpdateRoomTypeAsync(Guid id, RoomTypeForUpdateDto roomType, bool trackChanges);
    Task<(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity)> GetRoomTypeForPatchAsync
        (Guid id, bool trackChanges);
    Task SaveChangesForPatchAsync(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity);
    Task DeleteRoomTypeAsync(Guid id, bool trackChanges);
}