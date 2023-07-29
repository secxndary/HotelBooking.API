using Entities.Models;
namespace Repository.Extentsions;

public static class RoleRepositoryExtensions
{
    public static IQueryable<Role> Search(this IQueryable<Role> roles, string searchTerm)
    {
        if (string.IsNullOrWhiteSpace(searchTerm))
            return roles;

        var lowerCaseTerm = searchTerm.Trim().ToLower();

        var rolesWithSearchTermInName = roles
            .Where(r => r.Name.ToLower().Contains(lowerCaseTerm))
            .Select(r => new { Role = r, Priority = 1 });

        var rolesWithSearchTermInDescription = roles
            .Where(r =>
                !r.Name.ToLower().Contains(lowerCaseTerm) &&
                r.Description.ToLower().Contains(lowerCaseTerm))
            .Select(r => new { Role = r, Priority = 2 });

        var result = rolesWithSearchTermInName
            .Union(rolesWithSearchTermInDescription)
            .OrderBy(r => r.Priority)
            .Select(r => r.Role);

        return result;
    }
}
