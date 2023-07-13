using Contracts.Repositories.UserRepositories;
using Entities.Models;
namespace Repository.UserRepositoriesImpl;

public class HotelPhotoRepository : RepositoryBase<HotelPhoto>, IHotelPhotoRepository
{
    public HotelPhotoRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    { }

    public IEnumerable<HotelPhoto> GetHotelPhotos(Guid hotelId, bool trackChanges) =>
        FindByCondition(p => p.HotelId.Equals(hotelId), trackChanges)
        .OrderBy(p => p.Path)
        .ToList();

    public HotelPhoto GetHotelPhoto(Guid hotelId, Guid id, bool trackChanges) =>
        FindByCondition(p =>
            p.HotelId.Equals(hotelId) &&
            p.Id.Equals(id), trackChanges)
        .SingleOrDefault();
}