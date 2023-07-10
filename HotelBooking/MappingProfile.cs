using AutoMapper;
using Entities.Models;
using Shared.DataTransferObjects;
namespace HotelBooking;

public class MappingProfile : Profile
{
    public MappingProfile() 
    {
        CreateMap<Role, RoleDto>();
    }
}