using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
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

        CreateMap<RoleForCreationDto, Role>();
        CreateMap<UserForCreationDto, User>();
        CreateMap<RoomTypeForCreationDto, RoomType>();
        CreateMap<RoomForCreationDto, Room>();
        CreateMap<HotelForCreationDto, Hotel>();
        CreateMap<ReservationForCreationDto, Reservation>();
        CreateMap<FeedbackForCreationDto, Feedback>();
        CreateMap<RoomPhotoForCreationDto, RoomPhoto>();
        CreateMap<HotelPhotoForCreationDto, HotelPhoto>();

        CreateMap<RoleForUpdateDto, Role>().ReverseMap();
        CreateMap<UserForUpdateDto, User>().ReverseMap();
        CreateMap<RoomTypeForUpdateDto, RoomType>().ReverseMap();
        CreateMap<RoomForUpdateDto, Room>().ReverseMap();
        CreateMap<HotelForUpdateDto, Hotel>().ReverseMap();
        CreateMap<ReservationForUpdateDto, Reservation>().ReverseMap();
        CreateMap<FeedbackForUpdateDto, Feedback>().ReverseMap();
        CreateMap<RoomPhotoForUpdateDto, RoomPhoto>().ReverseMap();
        CreateMap<HotelPhotoForUpdateDto, HotelPhoto>().ReverseMap();
    }
}