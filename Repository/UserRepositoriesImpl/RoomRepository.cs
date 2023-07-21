using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository.UserRepositoriesImpl;

public class RoomRepository : RepositoryBase<Room>, IRoomRepository
{
    public RoomRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public async Task<IEnumerable<Room>> GetRoomsAsync(Guid hotelId, bool trackChanges) =>
        await FindByCondition(r => r.HotelId.Equals(hotelId), trackChanges)
        .OrderBy(r => r.Price)
        .ToListAsync();

    public async Task<IEnumerable<Room>> GetByIdsForHotelAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(r =>
            r.HotelId.Equals(hotelId) &&
            ids.Contains(r.Id), trackChanges)
        .OrderBy(r => r.Price)
        .ToListAsync();

    public async Task<Room?> GetRoomAsync(Guid hotelId, Guid id, bool trackChanges) =>
        await FindByCondition(r => 
            r.HotelId.Equals(hotelId) && 
            r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public async Task<Room?> GetRoomAsync(Guid id, bool trackChanges) =>
        await FindByCondition(r => r.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateRoomForHotel(Guid hotelId, Room room)
    {
        room.HotelId = hotelId;
        Create(room);
    }

    public void DeleteRoom(Room room) =>
        Delete(room);
}