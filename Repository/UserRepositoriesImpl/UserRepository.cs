using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extentsions;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Repository.UserRepositoriesImpl;

public class UserRepository : RepositoryBase<User>, IUserRepository
{
    public UserRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<PagedList<User>> GetAllUsersAsync(UserParameters userParameters, bool trackChanges)
    {
        var users = await FindAll(trackChanges)
            .Search(userParameters.SearchTerm)
            .Sort(userParameters.OrderBy)
            .ToListAsync();

        return PagedList<User>.ToPagedList(users, userParameters.PageNumber, userParameters.PageSize);
    }

    public async Task<User?> GetUserAsync(Guid id, bool trackChanges) =>
        await FindByCondition(u => u.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateUser(User user) =>
        Create(user);

    public void DeleteUser(User user) =>
        Delete(user);
}