using Contracts.Repositories.UserRepositories;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository.UserRepositoriesImpl;

public class HotelPhotoRepository : RepositoryBase<HotelPhoto>, IHotelPhotoRepository
{
    public HotelPhotoRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }


    public async Task<IEnumerable<HotelPhoto>> GetHotelPhotosAsync(Guid hotelId, bool trackChanges) =>
        await FindByCondition(p => p.HotelId.Equals(hotelId), trackChanges)
        .OrderBy(p => p.Path)
        .ToListAsync();

    public async Task<IEnumerable<HotelPhoto>> GetByIdsAsync(Guid hotelId, IEnumerable<Guid> ids, bool trackChanges) =>
        await FindByCondition(p =>
            p.HotelId.Equals(hotelId) &&
            ids.Contains(p.Id), trackChanges)
        .OrderBy(p => p.Path)
        .ToListAsync();

    public async Task<HotelPhoto?> GetHotelPhotoAsync(Guid hotelId, Guid id, bool trackChanges) =>
        await FindByCondition(p =>
            p.HotelId.Equals(hotelId) &&
            p.Id.Equals(id), trackChanges)
        .SingleOrDefaultAsync();

    public void CreateHotelPhoto(Guid hotelId, HotelPhoto hotelPhoto)
    {
        hotelPhoto.HotelId = hotelId;
        Create(hotelPhoto);
    }

    public void DeleteHotelPhoto(HotelPhoto hotelPhoto) =>
        Delete(hotelPhoto);
}