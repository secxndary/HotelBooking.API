using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models.UserModels;

public class Hotel
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Введите название")]
    [MaxLength(50, ErrorMessage = "Максимальная длина названия – 50 символов")]
    public string? Name { get; set; }

    [Required(ErrorMessage = "Введите описание")]
    [MaxLength(3000, ErrorMessage = "Максимальная длина описания – 3000 символов")]
    public string? Description { get; set; }

    [Range(1, 5, ErrorMessage = "Количество звёзд должно быть в диапазоне от 1 до 5")]
    [Required(ErrorMessage = "Введите количество звёзд")]
    public int Stars { get; set; }

    [Required(ErrorMessage = "Введите адрес")]
    [MaxLength(500, ErrorMessage = "Максимальная длина описания – 500 символов")]
    public string? Address { get; set; }

    [ForeignKey(nameof(UserIdentity))]
    public string? HotelOwnerId { get; set; }
    public UserIdentity? HotelOwner { get; set; }
    
    public ICollection<Room>? Rooms { get; set; }
    public ICollection<HotelPhoto>? HotelPhotos { get; set; }
}
