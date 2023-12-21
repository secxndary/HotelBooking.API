using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models.UserModels;

public class Room
{
    public Guid Id { get; set; }

    [Range(0, 99999, ErrorMessage = "Цена должна быть в диапазоне от 0 до 99999")]
    [Required(ErrorMessage = "Введите цену")]
    public double Price { get; set; }

    [Range(0, 999, ErrorMessage = "Количество комнат должно быть в диапазоне от 0 до 999")]
    [Required(ErrorMessage = "Введите количество комнат")]
    public int Quantity { get; set; }

    [Range(1, 16, ErrorMessage = "Количество спальных мест должно быть в диапазоне от 0 до 16")]
    [Required(ErrorMessage = "Введите количество спальных мест")]
    public int SleepingPlaces { get; set; }

    [ForeignKey(nameof(Hotel))]
    public Guid HotelId { get; set; }
    public Hotel? Hotel { get; set; }

    [ForeignKey(nameof(RoomType))]
    public Guid RoomTypeId { get; set; }
    public RoomType? RoomType { get; set; }

    public ICollection<RoomPhoto>? RoomPhotos { get; set; }
    public ICollection<Reservation>? Reservations { get; set; }
}