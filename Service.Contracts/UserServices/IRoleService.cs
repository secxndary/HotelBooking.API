using Entities.Models;
namespace Service.Contracts.UserServices;

public interface IRoleService
{
    IEnumerable<Role> GetAllRoles(bool trackChanges);
}