using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IFeedbackService
{
    Task<IEnumerable<FeedbackDto>> GetFeedbacksForHotelAsync(Guid hotelId);
    Task<IEnumerable<FeedbackDto>> GetFeedbacksForRoomAsync(Guid roomId);
    Task<IEnumerable<FeedbackDto>> GetFeedbacksForReservationAsync(Guid reservationId);
    Task<FeedbackDto> GetFeedbackAsync(Guid id);
    Task<FeedbackDto> CreateFeedbackForReservationAsync(Guid reservationId, FeedbackForCreationDto feedback);
    Task<FeedbackDto> UpdateFeedbackAsync(Guid id, FeedbackForUpdateDto feedbackForUpdate);
    Task<(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity)> GetFeedbackForPatchAsync(Guid id);
    Task<FeedbackDto> SaveChangesForPatchAsync(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity);
    Task DeleteFeedbackAsync(Guid id);
}