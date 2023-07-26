using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Repository.UserRepositoriesImpl;

public class HotelRepository : RepositoryBase<Hotel>, IHotelRepository
{
    public HotelRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<PagedList<Hotel>> GetAllHotelsAsync(HotelParameters hotelParameters, bool trackChanges)
    {
        var hotels = await FindAll(trackChanges)
            .OrderByDescending(h => h.Stars)
            .ToListAsync();

        return PagedList<Hotel>.ToPagedList(hotels, hotelParameters.PageNumber, hotelParameters.PageSize);
    }

    public async Task<IEnumerable<Hotel>> GetByIdsAsync(IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(h => ids.Contains(h.Id), trackChanges)
        .ToListAsync();

    public async Task<Hotel?> GetHotelAsync(Guid id, bool trackChanges) =>
        await FindByCondition(h => h.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateHotel(Hotel hotel) => 
        Create(hotel);

    public void DeleteHotel(Hotel hotel) =>
       Delete(hotel);
}