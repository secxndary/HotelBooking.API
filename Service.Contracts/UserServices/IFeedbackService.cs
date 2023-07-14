﻿using Shared.DataTransferObjects.OutputDtos;
namespace Service.Contracts.UserServices;

public interface IFeedbackService
{
    IEnumerable<FeedbackDto> GetFeedbacksForHotel(Guid hotelId, bool trackChanges);
    IEnumerable<FeedbackDto> GetFeedbacksForRoom(Guid roomId, bool trackChanges);
    IEnumerable<FeedbackDto> GetFeedbacksForReservation(Guid reservationId, bool trackChanges);
    FeedbackDto GetFeedbackForHotel(Guid hotelId, Guid id, bool trackChanges);
    FeedbackDto GetFeedbackForRoom(Guid roomId, Guid id, bool trackChanges);
    FeedbackDto GetFeedbackForReservation(Guid reservationId, Guid id, bool trackChanges);
    FeedbackDto GetFeedback(Guid id, bool trackChanges);
    void DeleteFeedbackForHotel(Guid hotelId, Guid id, bool trackChanges);
    void DeleteFeedbackForRoom(Guid roomId, Guid id, bool trackChanges);
    void DeleteFeedbackForReservation(Guid reservationId, Guid id, bool trackChanges);
    void DeleteFeedback(Guid id, bool trackChanges);
}