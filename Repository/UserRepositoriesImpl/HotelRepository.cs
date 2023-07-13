using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
{
    public HotelRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<Hotel> GetAllHotels(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderByDescending(h => h.Stars)
        .ToList();

    public IEnumerable<Hotel> GetByIds(IEnumerable<Guid> ids, bool trackChanges) =>
        FindByCondition(h => ids.Contains(h.Id), trackChanges)
        .ToList();

    public Hotel GetHotel(Guid id, bool trackChanges) =>
        FindByCondition(h => h.Id.Equals(id), trackChanges)
        .SingleOrDefault();

    public void CreateHotel(Hotel hotel) => 
        Create(hotel);
}