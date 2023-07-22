using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoomTypeService
{
    Task<IEnumerable<RoomTypeDto>> GetAllRoomTypesAsync();
    Task<RoomTypeDto> GetRoomTypeAsync(Guid id);
    Task<RoomTypeDto> CreateRoomTypeAsync(RoomTypeForCreationDto roomType);
    Task<RoomTypeDto> UpdateRoomTypeAsync(Guid id, RoomTypeForUpdateDto roomType);
    Task<(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity)> GetRoomTypeForPatchAsync(Guid id);
    Task<RoomTypeDto> SaveChangesForPatchAsync(RoomTypeForUpdateDto roomTypeToPatch, RoomType roomTypeEntity);
    Task DeleteRoomTypeAsync(Guid id);
}