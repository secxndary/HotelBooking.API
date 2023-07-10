using Service.Contracts.UserServices;
namespace Service.Contracts;

public interface IServiceManager
{
    IRoleService RoleService { get; }
    IUserService UserService { get; }
    IRoomTypeService RoomTypeService { get; }
    IRoomService RoomService { get; }
    IHotelService HotelService { get; }
    IReservationService ReservationService { get; }
    IFeedbackService FeedbackService { get; }
    IRoomPhotoService RoomPhotoService { get; }
    IHotelPhotoService HotelPhotoService { get; }
}