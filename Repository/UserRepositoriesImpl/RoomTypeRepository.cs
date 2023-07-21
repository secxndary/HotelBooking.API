using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository.UserRepositoriesImpl;

public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<IEnumerable<RoomType>> GetAllRoomTypesAsync(bool trackChanges) =>
        await FindAll(trackChanges)
        .OrderBy(r => r.Name)
        .ToListAsync();

    public async Task<RoomType?> GetRoomTypeAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateRoomType(RoomType roomType) =>
        Create(roomType);

    public void DeleteRoomType(RoomType roomType) =>
        Delete(roomType);
}