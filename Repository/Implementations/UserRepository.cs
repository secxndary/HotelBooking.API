using Contracts.Repositories;
using Entities.Models;
namespace Repository.Implementations;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


}