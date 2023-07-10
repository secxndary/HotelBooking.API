using Contracts;
using Contracts.Repository;
using Service.Contracts.UserServices;
namespace Service.UserServicesImpl;

public sealed class HotelService : IHotelService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public HotelService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

}