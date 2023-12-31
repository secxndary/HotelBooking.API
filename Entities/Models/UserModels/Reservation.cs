﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models.UserModels;

public class Reservation
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Введите дату заезда")]
    public DateTime DateEntry { get; set; }

    [Required(ErrorMessage = "Введите дату выезда")]
    public DateTime DateExit { get; set; }

    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; set; }
    public Room? Room { get; set; }

    [ForeignKey(nameof(UserIdentity))]
    public string? UserId { get; set; }
    public UserIdentity? User { get; set; }

    public ICollection<Feedback>? Feedbacks { get; set; }
}
