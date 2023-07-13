using Shared.DataTransferObjects;
namespace Service.Contracts.UserServices;

public interface IRoleService
{
    IEnumerable<RoleDto> GetAllRoles(bool trackChanges);
    RoleDto GetRole(Guid id, bool trackChanges);
    void DeleteRole(Guid id, bool trackChanges);
}