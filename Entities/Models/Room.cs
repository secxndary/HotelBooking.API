using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models;

public class Room
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Price is a required field.")]
    public double Price { get; set; }

    [Required(ErrorMessage = "Quantity is a required field.")]
    public int Quantity { get; set; }

    [Required(ErrorMessage = "SleepingPlaces is a required field.")]
    [Range(1, 8)]
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