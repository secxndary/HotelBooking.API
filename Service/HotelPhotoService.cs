using Contracts;
using Contracts.Repository;
using Service.Contracts;
namespace Service;

public sealed class HotelPhotoService : IHotelPhotoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;

    public HotelPhotoService(IRepositoryManager repository, ILoggerManager logger)
    {
        _repository = repository;
        _logger = logger;
    }

}