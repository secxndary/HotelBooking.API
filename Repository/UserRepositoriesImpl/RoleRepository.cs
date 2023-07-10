using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<Role> GetAllRoles(bool trackChanges) =>
        FindAll(trackChanges)
            .OrderBy(r => r.Name)
            .ToList();
}