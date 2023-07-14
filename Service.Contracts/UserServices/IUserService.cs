using Shared.DataTransferObjects.OutputDtos;

namespace Service.Contracts.UserServices;

public interface IUserService
{
    IEnumerable<UserDto> GetAllUsers(bool trackChanges);
    UserDto GetUser(Guid id, bool trackChanges);
    void DeleteUser(Guid id, bool trackChanges);
}