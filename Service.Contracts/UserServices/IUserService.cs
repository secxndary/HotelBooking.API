using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IUserService
{
    Task<IEnumerable<UserDto>> GetAllUsersAsync(bool trackChanges);
    Task<UserDto> GetUserAsync(Guid id, bool trackChanges);
    Task<UserDto> CreateUserAsync(UserForCreationDto user);
    Task UpdateUserAsync(Guid id, UserForUpdateDto user, bool trackChanges);
    Task<(UserForUpdateDto userToPatch, User userEntity)> GetUserForPatchAsync(Guid id, bool trackChanges);
    Task SaveChangesForPatchAsync(UserForUpdateDto userToPatch, User userEntity);
    Task DeleteUserAsync(Guid id, bool trackChanges);
}