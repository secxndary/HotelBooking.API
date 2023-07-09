using Contracts.Repository;
using Entities.Models;

namespace Repository.RepositoryUser;

public class RoleRepository : RepositoryBase<Role>, IRoleRepository
{
    public RoleRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}