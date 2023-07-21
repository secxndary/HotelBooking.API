using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository.UserRepositoriesImpl;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<IEnumerable<User>> GetAllUsersAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .ToListAsync();

    public async Task<User?> GetUserAsync(Guid id, bool trackChanges) =>
        await FindByCondition(u => u.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateUser(User user) =>
        Create(user);

    public void DeleteUser(User user) =>
        Delete(user);
}