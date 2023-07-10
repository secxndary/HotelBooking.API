using Shared.DataTransferObjects;
namespace Service.Contracts.UserServices;

public interface IRoleService
{
    IEnumerable<RoleDto> GetAllRoles(bool trackChanges);
}