using Entities.Models;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Contracts.Repositories.UserRepositories;

public interface IRoleRepository
{
    Task<PagedList<Role>> GetAllRolesAsync(RoleParameters roleParameters, bool trackChanges);
    Task<Role?> GetRoleAsync(Guid id, bool trackChanges);
    void CreateRole(Role role);
    void DeleteRole(Role role);
}