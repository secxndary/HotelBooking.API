using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IUserService
{
    IEnumerable<UserDto> GetAllUsers(bool trackChanges);
    UserDto GetUser(Guid id, bool trackChanges);
    UserDto CreateUser(UserForCreationDto user);
    void UpdateUser(Guid id, UserForUpdateDto user, bool trackChanges);
    (UserForUpdateDto userToPatch, User userEntity) GetUserForPatch(Guid id, bool trackChanges);
    void SaveChangesForPatch(UserForUpdateDto userToPatch, User userEntity);
    void DeleteUser(Guid id, bool trackChanges);
}