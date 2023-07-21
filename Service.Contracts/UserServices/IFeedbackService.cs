using Entities.Models;
using Shared.DataTransferObjects.InputDtos;
using Shared.DataTransferObjects.OutputDtos;
using Shared.DataTransferObjects.UpdateDtos;
namespace Service.Contracts.UserServices;

public interface IFeedbackService
{
    Task<IEnumerable<FeedbackDto>> GetFeedbacksForHotelAsync(Guid hotelId, bool trackChanges);
    Task<IEnumerable<FeedbackDto>> GetFeedbacksForRoomAsync(Guid roomId, bool trackChanges);
    Task<IEnumerable<FeedbackDto>> GetFeedbacksForReservationAsync(Guid reservationId, bool trackChanges);
    Task<FeedbackDto> GetFeedbackAsync(Guid id, bool trackChanges);
    Task<FeedbackDto> CreateFeedbackForReservationAsync(Guid reservationId, 
        FeedbackForCreationDto feedback, bool trackChanges);
    Task UpdateFeedbackAsync(Guid id, FeedbackForUpdateDto feedbackForUpdate, bool trackChanges);
    Task<(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity)> GetFeedbackForPatchAsync
        (Guid id, bool trackChanges);
    Task SaveChangesForPatchAsync(FeedbackForUpdateDto feedbackToPatch, Feedback feedbackEntity);
    Task DeleteFeedbackAsync(Guid id, bool trackChanges);
}