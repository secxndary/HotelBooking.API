using Contracts.Repositories;
using Entities.Models;
namespace Repository.Implementations;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}