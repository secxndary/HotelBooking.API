using System.ComponentModel.DataAnnotations;
namespace Shared.DataTransferObjects.Contracts;

public record HotelForManipulationDto
{
    [Required(ErrorMessage = "Введите название")]
    [MaxLength(50, ErrorMessage = "Максимальная длина названия – 50 символов")]
    public string? Name { get; init; }

    [Required(ErrorMessage = "Введите описание")]
    [MaxLength(3000, ErrorMessage = "Максимальная длина описания – 3000 символов")]
    public string? Description { get; init; }

    [Range(1, 5, ErrorMessage = "Количество звёзд должно быть в диапазоне от 1 до 5")]
    [Required(ErrorMessage = "Введите количество звёзд")]
    public int Stars { get; init; }

    [Required(ErrorMessage = "Введите адрес")]
    [MaxLength(500, ErrorMessage = "Максимальная длина описания – 500 символов")]
    public string? Address { get; init; }

    [Required(ErrorMessage = "Введите идентфиикатор владельца отеля")]
    public string? HotelOwnerId { get; set; }
}