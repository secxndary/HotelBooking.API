using Entities.Models;
namespace Repository.Extentsions;

public static class RoomPhotoRepositoryExtensions
{
    public static IQueryable<RoomPhoto> Search(this IQueryable<RoomPhoto> roomPhotos, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return roomPhotos;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        return roomPhotos.Where(p => p.Path.ToLower().Contains(lowerCaseTerm));
    }
}
