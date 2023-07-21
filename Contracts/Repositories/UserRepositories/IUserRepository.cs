using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges);
    Task<User?> GetUserAsync(Guid id, bool trackChanges);
    void CreateUser(User user);
    void DeleteUser(User user);
}