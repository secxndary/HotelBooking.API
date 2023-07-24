using Entities.Models;
namespace Repository.Extentsions;

public static class RepositoryRoomExtensions
{
    public static IQueryable<Room> FilterRoomsBySleepingPlaces(this IQueryable<Room> rooms, uint minSleepingPlaces, uint maxSleepingPlaces) =>
        rooms.Where(r => r.SleepingPlaces >= minSleepingPlaces && r.SleepingPlaces <= maxSleepingPlaces);
}
