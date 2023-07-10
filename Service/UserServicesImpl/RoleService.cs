using Contracts;
using Contracts.Repository;
using Entities.Models;
using Service.Contracts.UserServices;
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


    public IEnumerable<Role> GetAllRoles(bool trackChanges)
    {
        try
        {
            var roles = _repository.Role.GetAllRoles(trackChanges);
            return roles;
        }
        catch(Exception ex)
        {
            _logger.LogError($"Something went wrong in the {nameof(GetAllRoles)} service method {ex}");
            throw;
        }
    }
}