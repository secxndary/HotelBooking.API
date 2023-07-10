using Contracts;
using Contracts.Repository;
using Service.Contracts.UserServices;
namespace Service.UserServicesImpl;

public sealed class RoomPhotoService : IRoomPhotoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public RoomPhotoService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

}