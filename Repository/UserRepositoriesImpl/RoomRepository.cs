using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<Room> GetRooms(Guid hotelId, bool trackChanges) =>
        FindByCondition(r => r.HotelId.Equals(hotelId), trackChanges)
            .OrderBy(r => r.Price)
            .ToList();
}