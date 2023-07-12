using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<User> GetAllUsers(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();

    public User GetUser(Guid id, bool trackChanges) =>
        FindByCondition(u => u.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}