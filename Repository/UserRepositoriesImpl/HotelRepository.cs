using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.Implementations;

public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
{
    public HotelRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<Hotel> GetAllHotels(bool trackChanges) =>
        FindAll(trackChanges)
        .OrderByDescending(h => h.Stars)
        .ToList();

    public Hotel GetHotel(Guid id, bool trackChanges) =>
        FindByCondition(h => h.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}