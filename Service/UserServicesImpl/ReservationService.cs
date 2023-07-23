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


    public async Task<IEnumerable<ReservationDto>> GetReservationsAsync(Guid roomId)
    {
        await CheckIfRoomExists(roomId);

        var reservations = await _repository.Reservation.GetReservationsAsync(roomId, trackChanges: false);
        var reservationsDto = _mapper.Map<IEnumerable<ReservationDto>>(reservations);
        
        return reservationsDto;
    }

    public async Task<ReservationDto> GetReservationAsync(Guid roomId, Guid id)
    {
        await CheckIfRoomExists(roomId);

        var reservation = await GetReservationAndCheckIfItExists(id, trackChanges: false);
        var reservationDto = _mapper.Map<ReservationDto>(reservation);
        
        return reservationDto;
    }

    public async Task<ReservationDto> CreateReservationForRoomAsync(Guid roomId, ReservationForCreationDto reservation)
    {
        await CheckIfRoomExists(roomId);
        await CheckIfUserExists(reservation.UserId);

        var reservationEntity = _mapper.Map<Reservation>(reservation);
        _repository.Reservation.CreateReservationForRoom(roomId, reservationEntity);
        await _repository.SaveAsync();

        var reservationToReturn = _mapper.Map<ReservationDto>(reservationEntity); 
        return reservationToReturn;
    }

    public async Task<ReservationDto> UpdateReservationForRoomAsync(Guid roomId, Guid id, ReservationForUpdateDto reservation)
    {
        await CheckIfRoomExists(roomId);
        await CheckIfUserExists(reservation.UserId);

        var reservationEntity = await GetReservationAndCheckIfItExists(id, trackChanges: true);
        _mapper.Map(reservation, reservationEntity);
        await _repository.SaveAsync();

        var reservationToReturn = _mapper.Map<ReservationDto>(reservationEntity);
        return reservationToReturn;
    }

    public async Task<(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity)> 
        GetReservationForPatchAsync(Guid roomId, Guid id)
    {
        await CheckIfRoomExists(roomId);

        var reservationEntity = await GetReservationAndCheckIfItExists(id, trackChanges: true);
        var reservationToPatch = _mapper.Map<ReservationForUpdateDto>(reservationEntity);
        
        return (reservationToPatch, reservationEntity);
    }

    public async Task<ReservationDto> SaveChangesForPatchAsync(ReservationForUpdateDto reservationToPatch, Reservation reservationEntity)
    {
        _mapper.Map(reservationToPatch, reservationEntity);
        await _repository.SaveAsync();

        var reservationToReturn = _mapper.Map<ReservationDto>(reservationEntity);
        return reservationToReturn;
    }

    public async Task DeleteReservationForRoomAsync(Guid roomId, Guid id) 
    {
        await CheckIfRoomExists(roomId);

        var reservation = await GetReservationAndCheckIfItExists(id, trackChanges: true);

        _repository.Reservation.DeleteReservation(reservation);
        await _repository.SaveAsync();
    }


    private async Task CheckIfRoomExists(Guid roomId)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges: false);
        if (room is null)
            throw new RoomNotFoundException(roomId);
    }

    private async Task CheckIfUserExists(Guid userId)
    {
        var user = await _repository.User.GetUserAsync(userId, trackChanges: false);
        if (user is null)
            throw new UserNotFoundException(userId);
    }

    private async Task<Reservation> GetReservationAndCheckIfItExists(Guid id, bool trackChanges)
    {
        var reservation = await _repository.Reservation.GetReservationAsync(id, trackChanges);
        if (reservation is null)
            throw new ReservationNotFoundException(id);
        return reservation;
    }
}