namespace Shared.DataTransferObjects.InputDtos;

public record FeedbackForCreationDto
(
    string TextPositive,
    string TextNegative,
    Guid ReservationId
);