﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Entities.Models;

public class Reservation
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "DateEntry is a required field.")]
    public DateTime DateEntry { get; set; }
    
    [Required(ErrorMessage = "DateExit is a required field.")]
    public DateTime DateExit { get; set; }

    [ForeignKey(nameof(Room))]
    public Guid RoomId { get; set; }
    public Room? Room { get; set; }

    [ForeignKey(nameof(User))]
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public ICollection<Feedback>? Feedbacks { get; set; }
}