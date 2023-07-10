using Contracts;
using Contracts.Repository;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects;

namespace Service.UserServicesImpl;

public sealed class RoleService : IRoleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public RoleService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }


    public IEnumerable<RoleDto> GetAllRoles(bool trackChanges)
    {
        try
        {
            var roles = _repository.Role.GetAllRoles(trackChanges);
            var rolesDto = roles
                .Select(r => new RoleDto(r.Id, r.Name ?? "", r.Description ?? ""))
                .ToList();
            return rolesDto;
        }
        catch(Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllRoles)} service method {ex}");
            throw;
        }
    }
}