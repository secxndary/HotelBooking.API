using Contracts.Repositories;

namespace Contracts.Repository;

public interface IRepositoryManager
{
    IRoleRepository RoleRepository { get; }
    IUserRepository UserRepository { get; }
    IRoomTypeRepository RoomTypeRepository { get; }
    IRoomRepository RoomRepository { get; }
    IHotelRepository HotelRepository { get; }
    IReservationRepository ReservationRepository { get; }
    IFeedbackRepository FeedbackRepository { get; }
    IRoomPhotoRepository RoomPhotoRepository { get; }
    IHotelPhotoRepository HotelPhotoRepository { get; }
}