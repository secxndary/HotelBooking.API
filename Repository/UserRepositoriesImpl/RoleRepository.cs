using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository.UserRepositoriesImpl;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<IEnumerable<Role>> GetAllRolesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(r => r.Name)
        .ToListAsync();

    public async Task<Role?> GetRoleAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateRole(Role role) =>
        Create(role);

    public void DeleteRole(Role role) =>
        Delete(role);
}