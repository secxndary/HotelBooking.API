using System.Reflection;
using System.Text;
using Entities.Models;
namespace Repository.Extentsions;

public static class RoomRepositoryExtensions
{
    public static IQueryable<Room> FilterRoomsBySleepingPlaces(this IQueryable<Room> rooms, uint minSleepingPlaces, uint maxSleepingPlaces) =>
        rooms.Where(r => r.SleepingPlaces >= minSleepingPlaces && r.SleepingPlaces <= maxSleepingPlaces);

    public static IQueryable<Room> FilterRoomsByPrice(this IQueryable<Room> rooms, uint minPrice, uint maxPrice) =>
        rooms.Where(r => r.Price >= minPrice && r.Price <= maxPrice);

    //public static IQueryable<Room> Sort(this IQueryable<Room> rooms, string orderByQueryString)
    //{
    //    if (string.IsNullOrWhiteSpace(orderByQueryString))
    //        return rooms.OrderBy(r => r.Price);

    //    var orderParams = orderByQueryString.Trim().Split(',');
    //    var propertyInfos = typeof(Room).GetProperties(BindingFlags.Public | BindingFlags.Instance);
    //    var orderQueryBuilder = new StringBuilder();

    //    foreach (var param in orderParams)
    //    {
    //        if (string.IsNullOrWhiteSpace(param))
    //            continue;

    //        var propertyFromQueryName = param.Split(" ")[0];
    //        var objectProperty = propertyInfos.FirstOrDefault(pi => 
    //            pi.Name.Equals(propertyFromQueryName, StringComparison.InvariantCultureIgnoreCase));

    //        if (objectProperty == null)
    //            continue;

    //        var direction = param.EndsWith(" desc") ? "descending" : "ascending";
    //        orderQueryBuilder.Append($"{objectProperty.Name.ToString()} {direction}, ");
    //    }

    //    var orderQuery = orderQueryBuilder.ToString().TrimEnd(',', ' ');

    //    if (string.IsNullOrWhiteSpace(orderQuery))
    //        return rooms.OrderBy(r => r.Price);

    //    return rooms.OrderBy(orderQuery);
    //}
}
