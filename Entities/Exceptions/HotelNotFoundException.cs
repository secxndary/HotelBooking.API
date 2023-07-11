namespace Entities.Exceptions;

public class HotelNotFoundException : Exception
{
    public HotelNotFoundException(Guid hotelId)
        : base($"The hotel with id: {hotelId} doesn't exist in the database.")
    { }
}
