﻿using AutoMapper;
using Contracts;
using Contracts.Repository;
using Service.Contracts;
using Service.Contracts.UserServices;
using Service.UserServicesImpl;
namespace Service;

public class ServiceManager : IServiceManager
{
    private readonly Lazy<IRoleService> _roleService;
    private readonly Lazy<IUserService> _userService;
    private readonly Lazy<IRoomTypeService> _roomTypeService;
    private readonly Lazy<IRoomService> _roomService;
    private readonly Lazy<IHotelService> _hotelService;
    private readonly Lazy<IReservationService> _reservationService;
    private readonly Lazy<IFeedbackService> _feedbackService;
    private readonly Lazy<IRoomPhotoService> _roomPhotoService;
    private readonly Lazy<IHotelPhotoService> _hotelPhotoService;

    public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _roleService = new Lazy<IRoleService>(() => new RoleService(repository, logger, mapper));
        _userService = new Lazy<IUserService>(() => new UserService(repository, logger, mapper));
        _roomTypeService = new Lazy<IRoomTypeService>(() => new RoomTypeService(repository, logger, mapper));
        _roomService = new Lazy<IRoomService>(() => new RoomService(repository, logger, mapper));
        _hotelService = new Lazy<IHotelService>(() => new HotelService(repository, logger, mapper));
        _reservationService = new Lazy<IReservationService>(() =>  new ReservationService(repository, logger, mapper));
        _feedbackService = new Lazy<IFeedbackService>(() => new FeedbackService(repository, logger, mapper));
        _roomPhotoService = new Lazy<IRoomPhotoService>(() => new RoomPhotoService(repository, logger, mapper));
        _hotelPhotoService = new Lazy<IHotelPhotoService>(() => new HotelPhotoService(repository, logger, mapper));
    }

    public IRoleService RoleService => _roleService.Value;
    public IUserService UserService => _userService.Value;
    public IRoomTypeService RoomTypeService => _roomTypeService.Value;
    public IRoomService RoomService => _roomService.Value;
    public IHotelService HotelService => _hotelService.Value;
    public IReservationService ReservationService => _reservationService.Value;
    public IFeedbackService FeedbackService => _feedbackService.Value;
    public IRoomPhotoService RoomPhotoService => _roomPhotoService.Value;
    public IHotelPhotoService HotelPhotoService => _hotelPhotoService.Value;
}