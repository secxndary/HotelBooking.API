using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync();
    Task<UserDto> GetUserAsync(Guid id);
    Task<UserDto> CreateUserAsync(UserForCreationDto user);
    Task UpdateUserAsync(Guid id, UserForUpdateDto user);
    Task<(UserForUpdateDto userToPatch, User userEntity)> GetUserForPatchAsync(Guid id);
    Task SaveChangesForPatchAsync(UserForUpdateDto userToPatch, User userEntity);
    Task DeleteUserAsync(Guid id);
}