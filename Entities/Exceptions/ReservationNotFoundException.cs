namespace Entities.Exceptions;

public class ReservationNotFoundException : NotFoundException
{
    public ReservationNotFoundException(Guid userId)
        : base($"Reservation with id: {userId} doesn't exist in the database.")
    { }
}