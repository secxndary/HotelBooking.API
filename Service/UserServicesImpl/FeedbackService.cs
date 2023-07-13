using AutoMapper;
using Contracts;
using Contracts.Repository;
using Entities.Exceptions.NotFound;
using Service.Contracts.UserServices;
using Shared.DataTransferObjects;
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


    public IEnumerable<FeedbackDto> GetFeedbacks(Guid hotelId, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);
        var feedbacks = _repository.Feedback.GetFeedbacks(hotelId, trackChanges);
        var feedbacksDto = _mapper.Map<IEnumerable<FeedbackDto>>(feedbacks);
        return feedbacksDto;
    }

    public FeedbackDto GetFeedback(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var feedback = _repository.Feedback.GetFeedback(hotelId, id, trackChanges);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        var feedbackDto = _mapper.Map<FeedbackDto>(feedback);
        return feedbackDto;
    }

    public void DeleteFeedbackForHotel(Guid hotelId, Guid id, bool trackChanges)
    {
        var hotel = _repository.Hotel.GetHotel(hotelId, trackChanges);
        if (hotel is null)
            throw new HotelNotFoundException(hotelId);

        var feedback = _repository.Feedback.GetFeedback(hotelId, id, trackChanges);
        if (feedback is null)
            throw new FeedbackNotFoundException(id);

        _repository.Feedback.DeleteFeedback(feedback);
        _repository.Save();
    }
}