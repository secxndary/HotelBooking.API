using Contracts.Repositories.UserRepositories;
using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Repository.Extentsions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Repository.UserRepositoriesImpl;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<PagedList<Role>> GetAllRolesAsync(RoleParameters roleParameters, bool trackChanges)
    {
        var roles = await FindAll(trackChanges)
            .Search(roleParameters.SearchTerm)
            .Sort(roleParameters.OrderBy)
            .ToListAsync();

        return PagedList<Role>.ToPagedList(roles, roleParameters.PageNumber, roleParameters.PageSize);
    }

    public async Task<Role?> GetRoleAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateRole(Role role) =>
        Create(role);

    public void DeleteRole(Role role) =>
        Delete(role);
}