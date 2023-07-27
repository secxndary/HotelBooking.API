using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
using Shared.RequestFeatures;
using Shared.RequestFeatures.UserParameters;
namespace Service.Contracts.UserServices;

public interface IRoleService
{
    Task<(IEnumerable<RoleDto> roles, MetaData metaData)> GetAllRolesAsync(RoleParameters roleParameters);
    Task<RoleDto> GetRoleAsync(Guid id);
    Task<RoleDto> CreateRoleAsync(RoleForCreationDto role);
    Task<RoleDto> UpdateRoleAsync(Guid id, RoleForUpdateDto role);
    Task<(RoleForUpdateDto roleToPatch, Role roleEntity)> GetRoleForPatchAsync(Guid id);
    Task<RoleDto> SaveChangesForPatchAsync(RoleForUpdateDto roleToPatch, Role roleEntity);
    Task DeleteRoleAsync(Guid id);
}