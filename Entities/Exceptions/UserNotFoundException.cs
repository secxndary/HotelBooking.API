﻿namespace Entities.Exceptions;

public class UserNotFoundException : NotFoundException
{
    public UserNotFoundException(Guid userId)
        : base($"User with id: {userId} doesn't exist in the database.")
    { }
}