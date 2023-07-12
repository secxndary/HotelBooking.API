﻿namespace Entities.Exceptions;

public class ReservationNotFoundException : NotFoundException
{
    public ReservationNotFoundException(Guid reservationId)
        : base($"Reservation with id: {reservationId} doesn't exist in the database.")
    { }
}