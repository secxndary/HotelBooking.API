using Contracts.Repository;
using Entities.Models;

namespace Repository.RepositoryUser;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}