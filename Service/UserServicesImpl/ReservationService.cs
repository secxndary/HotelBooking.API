using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Entities.Models;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.UserServicesImpl;

public sealed class ReservationService : IReservationService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public ReservationService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public IEnumerable<ReservationDto> GetReservations(Guid roomId, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var reservations = _repository.Reservation.GetReservations(roomId, trackChanges);
        var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        return reservationsDto;
    }

    public ReservationDto GetReservation(Guid roomId, Guid id, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var reservation = _repository.Reservation.GetReservation(roomId, id, trackChanges);
        if (reservation is null)
            throw new ReservationNotFoundException(id);

        var reservationDto = _mapper.Map<ReservationDto>(reservation);
        return reservationDto;
    }

    public ReservationDto CreateReservationForRoom(Guid roomId, 
        ReservationForCreationDto reservation, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var reservationEntity = _mapper.Map<Reservation>(reservation);
        _repository.Reservation.CreateReservationForRoom(roomId, reservationEntity);
        _repository.Save();

        var reservationToReturn = _mapper.Map<ReservationDto>(reservationEntity); 
        return reservationToReturn;
    }

    public void UpdateReservationForRoom(Guid roomId, Guid id, 
        ReservationForUpdateDto reservation, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges: false);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var user = _repository.User.GetUser(reservation.UserId, trackChanges: false);
        if (user is null)
            throw new UserNotFoundException(reservation.UserId);

        var reservationEntity = _repository.Reservation.GetReservation(id, trackChanges);
        if (reservationEntity is null)
            throw new ReservationNotFoundException(id);

        _mapper.Map(reservation, reservationEntity);
        _repository.Save();
    }

    public void DeleteReservationForRoom(Guid roomId, Guid id, bool trackChanges) 
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var reservation = _repository.Reservation.GetReservation(roomId, id, trackChanges);
        if (reservation is null)
            throw new ReservationNotFoundException(id);

        _repository.Reservation.DeleteReservation(reservation);
        _repository.Save();
    }
}