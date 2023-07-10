using AutoMapper;
using Contracts;
using Contracts.Repository;
using Service.Contracts.UserServices;
namespace Service.UserServicesImpl;

public sealed class HotelPhotoService : IHotelPhotoService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public HotelPhotoService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }

}