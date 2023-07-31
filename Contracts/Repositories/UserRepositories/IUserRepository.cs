using Entities.Models.UserModels;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IUserRepository
{
    Task<PagedList<User>> GetAllUsersAsync(UserParameters userParameters, bool trackChanges);
    Task<User?> GetUserAsync(Guid id, bool trackChanges);
    void CreateUser(User user);
    void DeleteUser(User user);
}