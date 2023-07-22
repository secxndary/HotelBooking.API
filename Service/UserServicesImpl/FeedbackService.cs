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

public sealed class FeedbackService : IFeedbackService
{
    private readonly IRepositoryManager _repository;
    private readonly ILoggerManager _logger;
    private readonly IMapper _mapper;

    public FeedbackService(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
    {
        _repository = repository;
        _logger = logger;
        _mapper = mapper;
    }


    public async Task<IEnumerable<FeedbackDto>> GetFeedbacksForHotelAsync(Guid hotelId)
    {
        var hotel = await _repository.Hotel.GetHotelAsync(hotelId, trackChanges: false);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var feedbacks = await _repository.Feedback.GetFeedbacksForHotelAsync(hotelId, trackChanges: false);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        return feedbacksDto;
    }

    public async Task<IEnumerable<FeedbackDto>> GetFeedbacksForRoomAsync(Guid roomId)
    {
        var room = await _repository.Room.GetRoomAsync(roomId, trackChanges: false);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var feedbacks = await _repository.Feedback.GetFeedbacksForRoomAsync(roomId, trackChanges: false);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        return feedbacksDto;
    }

    public async Task<IEnumerable<FeedbackDto>> GetFeedbacksForReservationAsync(Guid reservationId)
    {
        var reservation = await _repository.Reservation.GetReservationAsync(reservationId, trackChanges: false);
        if (reservation is null)
            throw new ReservationNotFoundException(reservationId);

        var feedbacks = await _repository.Feedback.GetFeedbacksForReservationAsync(reservationId, trackChanges: false);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        return feedbacksDto;
    }

    public async Task<FeedbackDto> GetFeedbackAsync(Guid id)
    {
        var feedback = await _repository.Feedback.GetFeedbackAsync(id, trackChanges: false);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
        return feedbackDto;
    }

    public async Task<FeedbackDto> CreateFeedbackForReservationAsync(Guid reservationId,
        FeedbackForCreationDto feedback)
    {
        var reservation = await _repository.Reservation.GetReservationAsync(reservationId, trackChanges: false);
        if (reservation is null)
            throw new ReservationNotFoundException(reservationId);

        var feedbackEntity = _mapper.Map<Feedback>(feedback);
        _repository.Feedback.CreateFeedbackForReservation(reservationId, feedbackEntity);
        await _repository.SaveAsync();

        var feedbackToReturn = _mapper.Map<FeedbackDto>(feedbackEntity);
        return feedbackToReturn;
    }

    public async Task UpdateFeedbackAsync(Guid id, FeedbackForUpdateDto feedbackForUpdate)
    {
        var reservation = await _repository.Reservation.GetReservationAsync
            (feedbackForUpdate.ReservationId, trackChanges: false);
        if (reservation is null)
            throw new ReservationNotFoundException(feedbackForUpdate.ReservationId);

        var feedbackEntity = await _repository.Feedback.GetFeedbackAsync(id, trackChanges: true);
        if (feedbackEntity is null)
            throw new FeedbackNotFoundException(id);

        _mapper.Map(feedbackForUpdate, feedbackEntity);
        await _repository.SaveAsync();
    }

    public async Task<(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity)> GetFeedbackForPatchAsync(Guid id)
    {
        var feedbackEntity = await _repository.Feedback.GetFeedbackAsync(id, trackChanges: true);
        if (feedbackEntity is null)
            throw new FeedbackNotFoundException(id);

        var feedbackToPatch = _mapper.Map<FeedbackForUpdateDto>(feedbackEntity);
        return (feedbackToPatch, feedbackEntity);
    }

    public async Task SaveChangesForPatchAsync(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity)
    {
        var reservation = await _repository.Reservation.GetReservationAsync
            (feedbackToPatch.ReservationId, trackChanges: false);
        if (reservation is null)
            throw new ReservationNotFoundException(feedbackToPatch.ReservationId);

        _mapper.Map(feedbackToPatch, feedbackEntity);
        await _repository.SaveAsync();
    }

    public async Task DeleteFeedbackAsync(Guid id)
    {
        var feedback = await _repository.Feedback.GetFeedbackAsync(id, trackChanges: false);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        _repository.Feedback.DeleteFeedback(feedback);
        await _repository.SaveAsync();
    }
}