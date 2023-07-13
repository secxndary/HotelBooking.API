using Shared.DataTransferObjects;
namespace Service.Contracts.UserServices;

public interface IFeedbackService
{
    IEnumerable<FeedbackDto> GetFeedbacks(Guid hotelId, bool trackChanges);
    FeedbackDto GetFeedback(Guid hotelId, Guid id, bool trackChanges);
    void DeleteFeedbackForHotel(Guid hotelId, Guid id, bool trackChanges);
}