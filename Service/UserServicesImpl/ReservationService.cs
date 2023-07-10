using Contracts;
using Contracts.Repository;
using Service.Contracts.UserServices;
namespace Service.UserServicesImpl;

public sealed class ReservationService : IReservationService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public ReservationService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

}