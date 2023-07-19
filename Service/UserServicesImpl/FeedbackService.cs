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


    public IEnumerable<FeedbackDto> GetFeedbacksForHotel(Guid hotelId, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var feedbacks = _repository.Feedback.GetFeedbacksForHotel(hotelId, trackChanges);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        return feedbacksDto;
    }

    public IEnumerable<FeedbackDto> GetFeedbacksForRoom(Guid roomId, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var feedbacks = _repository.Feedback.GetFeedbacksForRoom(roomId, trackChanges);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        return feedbacksDto;
    }

    public IEnumerable<FeedbackDto> GetFeedbacksForReservation(Guid reservationId, bool trackChanges)
    {
        var reservation = _repository.Reservation.GetReservation(reservationId, trackChanges);
        if (reservation is null)
            throw new ReservationNotFoundException(reservationId);

        var feedbacks = _repository.Feedback.GetFeedbacksForReservation(reservationId, trackChanges);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        return feedbacksDto;
    }

    public FeedbackDto GetFeedbackForHotel(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var feedback = _repository.Feedback.GetFeedbackForHotel(hotelId, id, trackChanges);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
        return feedbackDto;
    }

    public FeedbackDto GetFeedbackForRoom(Guid roomId, Guid id, bool trackChanges)
    {
        var room = _repository.Room.GetRoom(roomId, trackChanges);
        if (room is null)
            throw new RoomNotFoundException(roomId);

        var feedback = _repository.Feedback.GetFeedbackForRoom(roomId, id, trackChanges);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
        return feedbackDto;
    }

    public FeedbackDto GetFeedbackForReservation(Guid reservationId, Guid id, bool trackChanges)
    {
        var reservation = _repository.Reservation.GetReservation(reservationId, trackChanges);
        if (reservation is null)
            throw new ReservationNotFoundException(reservationId);

        var feedback = _repository.Feedback.GetFeedbackForReservation(reservationId, id, trackChanges);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
        return feedbackDto;
    }

    public FeedbackDto GetFeedback(Guid id, bool trackChanges)
    {
        var feedback = _repository.Feedback.GetFeedback(id, trackChanges);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
        return feedbackDto;
    }

    public FeedbackDto CreateFeedbackForReservation(Guid reservationId,
        FeedbackForCreationDto feedback, bool trackChanges)
    {
        var reservation = _repository.Reservation.GetReservation(reservationId, trackChanges);
        if (reservation is null)
            throw new ReservationNotFoundException(reservationId);

        var feedbackEntity = _mapper.Map<Feedback>(feedback);
        _repository.Feedback.CreateFeedbackForReservation(reservationId, feedbackEntity);
        _repository.Save();

        var feedbackToReturn = _mapper.Map<FeedbackDto>(feedbackEntity);
        return feedbackToReturn;
    }

    public void UpdateFeedback(Guid id, FeedbackForUpdateDto feedbackForUpdate, bool trackChanges)
    {
        var reservation = _repository.Reservation.GetReservation(feedbackForUpdate.ReservationId, false);
        if (reservation is null)
            throw new ReservationNotFoundException(feedbackForUpdate.ReservationId);

        var feedbackEntity = _repository.Feedback.GetFeedback(id, trackChanges);
        if (feedbackEntity is null)
            throw new FeedbackNotFoundException(id);

        _mapper.Map(feedbackForUpdate, feedbackEntity);
        _repository.Save();
    }

    public void DeleteFeedback(Guid id, bool trackChanges)
    {
        var feedback = _repository.Feedback.GetFeedback(id, trackChanges);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        _repository.Feedback.DeleteFeedback(feedback);
        _repository.Save();
    }
}