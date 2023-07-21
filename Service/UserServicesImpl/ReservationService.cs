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


    public async Task<IEnumerable<ReservationDto>> GetReservationsAsync(Guid roomId, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var reservations = await _repository.Reservation.GetReservationsAsync(roomId, trackChanges);
        var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        return reservationsDto;
    }

    public async Task<ReservationDto> GetReservationAsync(Guid roomId, Guid id, bool trackChanges)
    { 
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var reservation = await _repository.Reservation.GetReservationAsync(roomId, id, trackChanges);
        if (reservation is null)
            throw new ReservationNotFoundException(id);

        var reservationDto = _mapper.Map<ReservationDto>(reservation);
        return reservationDto;
    }

    public async Task<ReservationDto> CreateReservationForRoomAsync(Guid roomId, 
        ReservationForCreationDto reservation, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var user = await _repository.User.GetUserAsync(reservation.UserId, trackChanges: false);
        if (user is null)
            throw new UserNotFoundException(reservation.UserId);

        var reservationEntity = _mapper.Map<Reservation>(reservation);
        _repository.Reservation.CreateReservationForRoom(roomId, reservationEntity);
        await _repository.SaveAsync();

        var reservationToReturn = _mapper.Map<ReservationDto>(reservationEntity); 
        return reservationToReturn;
    }

    public async Task UpdateReservationForRoomAsync(Guid roomId, Guid id, 
        ReservationForUpdateDto reservation, bool trackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges: false);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var user = await _repository.User.GetUserAsync(reservation.UserId, trackChanges: false);
        if (user is null)
            throw new UserNotFoundException(reservation.UserId);

        var reservationEntity = await _repository.Reservation.GetReservationAsync(id, trackChanges);
        if (reservationEntity is null)
            throw new ReservationNotFoundException(id);

        _mapper.Map(reservation, reservationEntity);
        await _repository.SaveAsync();
    }

    public async Task<(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity)> GetReservationForPatchAsync
        (Guid roomId, Guid id, bool roomTrackChanges, bool reservationTrackChanges)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, roomTrackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var reservationEntity = await _repository.Reservation.GetReservationAsync(roomId, id, reservationTrackChanges);
        if (reservationEntity is null)
            throw new ReservationNotFoundException(id);

        var photoToPatch = _mapper.Map<ReservationForUpdateDto>(reservationEntity);
        return (photoToPatch, reservationEntity);
    }

    public async Task SaveChangesForPatchAsync(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity)
    {
        _mapper.Map(reservationToPatch, reservationEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteReservationForRoomAsync(Guid roomId, Guid id, bool trackChanges) 
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var reservation = await _repository.Reservation.GetReservationAsync(roomId, id, trackChanges);
        if (reservation is null)
            throw new ReservationNotFoundException(id);

        _repository.Reservation.DeleteReservation(reservation);
        await _repository.SaveAsync();
    }
}