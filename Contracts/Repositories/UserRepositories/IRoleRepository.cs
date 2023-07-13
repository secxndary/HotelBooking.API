using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoleRepository
{
    IEnumerable<Role> GetAllRoles(bool trackChanges);
    Role? GetRole(Guid id, bool trackChanges);
    void DeleteRole(Role role);
}