namespace Entities.Exceptions;

public class HotelNotFoundException : NotFoundException
{
    public HotelNotFoundException(Guid hotelId)
        : base($"The hotel with id: {hotelId} doesn't exist in the database.")
    { }
}
