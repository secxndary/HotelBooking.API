using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IRoleService
{
    Task<IEnumerable<RoleDto>> GetAllRolesAsync();
    Task<RoleDto> GetRoleAsync(Guid id);
    Task<RoleDto> CreateRoleAsync(RoleForCreationDto role);
    Task UpdateRoleAsync(Guid id, RoleForUpdateDto role);
    Task<(RoleForUpdateDto roleToPatch, Role roleEntity)> GetRoleForPatchAsync(Guid id);
    Task SaveChangesForPatchAsync(RoleForUpdateDto roleToPatch, Role roleEntity);
    Task DeleteRoleAsync(Guid id);
}