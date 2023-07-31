using Entities.Models.UserModels;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IUserService
{
    Task<(IEnumerable<UserDto> users, MetaData metaData)> GetAllUsersAsync(UserParameters userParameters);
    Task<UserDto> GetUserAsync(Guid id);
    Task<UserDto> CreateUserAsync(UserForCreationDto user);
    Task<UserDto> UpdateUserAsync(Guid id, UserForUpdateDto user);
    Task<(UserForUpdateDto userToPatch, User userEntity)> GetUserForPatchAsync(Guid id);
    Task<UserDto> SaveChangesForPatchAsync(UserForUpdateDto userToPatch, User userEntity);
    Task DeleteUserAsync(Guid id);
}