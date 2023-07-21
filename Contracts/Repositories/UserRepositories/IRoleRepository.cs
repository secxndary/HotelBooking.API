using Entities.Models;
namespace Contracts.Repositories.UserRepositories;

public interface IRoleRepository
{
    Task<IEnumerable<Role>> GetAllRolesAsync(bool trackChanges);
    Task<Role?> GetRoleAsync(Guid id, bool trackChanges);
    void CreateRole(Role role);
    void DeleteRole(Role role);
}