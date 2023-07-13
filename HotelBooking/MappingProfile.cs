using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
namespace HotelBooking;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Role, RoleDto>();
        CreateMap<User, UserDto>();
        CreateMap<RoomType, RoomTypeDto>();
        CreateMap<Room, RoomDto>();
        CreateMap<Hotel, HotelDto>();
        CreateMap<Reservation, ReservationDto>();
        CreateMap<Feedback, FeedbackDto>();
        CreateMap<RoomPhoto, RoomPhotoDto>();
        CreateMap<HotelPhoto,  HotelPhotoDto>();

        CreateMap<HotelForCreationDto, Hotel>();
    }
}