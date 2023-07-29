using Entities.Models;
namespace Repository.Extentsions;

public static class ReservationRepositoryExtensions
{
    public static IQueryable<Reservation> FilterReservationsByDateEntry
        (this IQueryable<Reservation> reservations, DateTime minDateEntry, DateTime maxDateEntry) =>
            reservations.Where(r => r.DateEntry >= minDateEntry && r.DateEntry <= maxDateEntry);

    public static IQueryable<Reservation> FilterReservationsByDateExit
        (this IQueryable<Reservation> reservations, DateTime minDateExit, DateTime maxDateExit) =>
            reservations.Where(r => r.DateExit >= minDateExit && r.DateExit <= maxDateExit);
}
