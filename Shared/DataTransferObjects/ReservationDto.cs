﻿namespace Shared.DataTransferObjects;

public record ReservationDto
{
    public Guid Id { get; init; }
    public DateTime DateEntry { get; init; }
    public DateTime DateExit { get; init; }

}