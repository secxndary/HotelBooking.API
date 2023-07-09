using Contracts.Repositories;
using Contracts.Repository;
using Repository.Implementations;
namespace Repository;

public sealed class RepositoryManager : IRepositoryManager
{
    private readonly RepositoryContext _repositoryContext;

    private readonly Lazy<IRoleRepository> _roleRepository;
    private readonly Lazy<IUserRepository> _userRepository;
    private readonly Lazy<IHotelRepository> _hotelRepository;
    private readonly Lazy<IRoomTypeRepository> _roomTypeRepository;
    private readonly Lazy<IRoomRepository> _roomRepository;
    private readonly Lazy<IReservationRepository> _reservationRepository;
    private readonly Lazy<IFeedbackRepository> _fedbackRepository;
    private readonly Lazy<IRoomPhotoRepository> _roomPhotoRepository;
    private readonly Lazy<IHotelPhotoRepository> _hotelPhotoRepository;

    public RepositoryManager(RepositoryContext repositoryContext)
    {
        _repositoryContext = repositoryContext;
        _roleRepository = new Lazy<IRoleRepository>(() => new RoleRepository(repositoryContext));
    }
}