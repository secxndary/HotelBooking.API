using AutoMapper;
using Contracts;
using Contracts.Repository;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects;
namespace Service.UserServicesImpl;

public sealed class RoleService : IRoleService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public RoleService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public IEnumerable<RoleDto> GetAllRoles(bool trackChanges)
    {
        var roles = _repository.Role.GetAllRoles(trackChanges);
        var rolesDto = _mapper.Map<IEnumerable<RoleDto>>(roles);
        return rolesDto;
    }
}