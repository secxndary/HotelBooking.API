using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync(bool trackChanges);
    Task<RoleDto> GetRoleAsync(Guid id, bool trackChanges);
    Task<RoleDto> CreateRoleAsync(RoleForCreationDto role);
    Task UpdateRoleAsync(Guid id, RoleForUpdateDto role, bool trackChanges);
    Task<(RoleForUpdateDto roleToPatch, Role roleEntity)> GetRoleForPatchAsync(Guid id, bool trackChanges);
    Task SaveChangesForPatchAsync(RoleForUpdateDto roleToPatch, Role roleEntity);
    Task DeleteRoleAsync(Guid id, bool trackChanges);
}