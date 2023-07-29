using Entities.Models;
namespace Repository.Extentsions;

public static class HotelPhotoRepositoryExtensions
{
    public static IQueryable<HotelPhoto> Search(this IQueryable<HotelPhoto> hotelPhotos, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return hotelPhotos;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return hotelPhotos.Where(p => p.Path.ToLower().Contains(lowerCaseTerm));
    }
}
