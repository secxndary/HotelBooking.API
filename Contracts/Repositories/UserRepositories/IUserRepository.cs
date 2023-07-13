using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IUserRepository
{
    IEnumerable<User> GetAllUsers(bool trackChanges);
    User? GetUser(Guid id, bool trackChanges);
    void DeleteUser(User user);
}