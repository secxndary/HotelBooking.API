using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<Role> GetAllRoles(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(r => r.Name)
        .ToList();

    public Role? GetRole(Guid id, bool trackChanges) =>
        FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateRole(Role role) =>
        Create(role);

    public void DeleteRole(Role role) =>
        Delete(role);
}