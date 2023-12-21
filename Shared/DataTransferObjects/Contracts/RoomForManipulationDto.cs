using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public abstract record RoomForManipulationDto
{
    [Range(0, 99999, ErrorMessage = "Цена должна быть в диапазоне от 0 до 99999")]
    [Required(ErrorMessage = "Введите цену")]
    public int Price { get; init; }

    [Range(0, 999, ErrorMessage = "Количество комнат должно быть в диапазоне от 0 до 999")]
    public int Quantity { get; init; }

    [Range(1, 16, ErrorMessage = "Количество спальных мест должно быть в диапазоне от 0 до 16")]
    [Required(ErrorMessage = "Введите количество спальных мест")]
    public int SleepingPlaces { get; init; }

    [Required(ErrorMessage = "Введите индентификатор отеля")]
    public Guid HotelId { get; init; }
    
    [Required(ErrorMessage = "Введите идентификатор типа комнаты")]
    public Guid RoomTypeId { get; init; }
}