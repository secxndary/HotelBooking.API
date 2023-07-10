using Contracts;
using Contracts.Repository;
using Service.Contracts.UserServices;
namespace Service.UserServicesImpl;

public sealed class RoomTypeService : IRoomTypeService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public RoomTypeService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

}