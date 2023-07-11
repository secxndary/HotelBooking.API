namespace Entities.Exceptions;

public class RoleNotFoundException : NotFoundException
{
    public RoleNotFoundException(Guid roleId)
        : base($"The role with id: {roleId} doesn't exist in the database.")
    { }
}