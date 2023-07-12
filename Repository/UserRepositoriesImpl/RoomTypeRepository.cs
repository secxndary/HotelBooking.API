using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class RoomTypeRepository : RepositoryBase<RoomType>, IRoomTypeRepository
{
    public RoomTypeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<RoomType> GetAllRoomTypes(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderBy(r => r.Name)
        .ToList();

    public RoomType GetRoomType(Guid id, bool trackChanges) =>
        FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}