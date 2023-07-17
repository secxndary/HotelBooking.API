using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<User> GetAllUsers(bool trackChanges) =>
        FindAll(trackChanges)
        .ToList();

    public User? GetUser(Guid id, bool trackChanges) =>
        FindByCondition(u => u.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateUser(User user) =>
        Create(user);

    public void DeleteUser(User user) =>
        Delete(user);
}