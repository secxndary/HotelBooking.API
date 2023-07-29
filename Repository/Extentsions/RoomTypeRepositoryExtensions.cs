using System.Data;
using Entities.Models;
namespace Repository.Extentsions;

public static class RoomTypeRepositoryExtensions
{
    public static IQueryable<RoomType> Search(this IQueryable<RoomType> roomTypes, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return roomTypes;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        var roomTypesWithSearchTermInName = roomTypes
            .Where(r => r.Name.ToLower().Contains(lowerCaseTerm))
            .Select(r => new { RoomType = r, Priority = 1 });

        var roomTypesWithSearchTermInDescription = roomTypes
            .Where(r =>
                !r.Name.ToLower().Contains(lowerCaseTerm) &&
                r.Description.ToLower().Contains(lowerCaseTerm))
            .Select(r => new { RoomType = r, Priority = 2 });

        var result = roomTypesWithSearchTermInName
            .Union(roomTypesWithSearchTermInDescription)
            .OrderBy(r => r.Priority)
            .Select(r => r.RoomType);

        return result;
    }
}
