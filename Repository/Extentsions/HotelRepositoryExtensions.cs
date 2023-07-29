using Entities.Models;
namespace Repository.Extentsions;

public static class HotelRepositoryExtensions
{
    public static IQueryable<Hotel> FilterHotelsByStars(this IQueryable<Hotel> hotels, uint minStars, uint maxStars) =>
        hotels.Where(h => h.Stars >= minStars && h.Stars <= maxStars);
}
