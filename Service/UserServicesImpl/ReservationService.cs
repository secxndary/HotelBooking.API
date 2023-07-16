using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects.OutputDtos;
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