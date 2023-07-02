using Entities.Models;
using Microsoft.EntityFrameworkCore;
namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) 
        : base (options)
    { }
    
    public DbSet<Role>? Roles { get; set; }
    public DbSet<RoomType>? RoomTypes { get; set; }
    public DbSet<RoomPhoto>? RoomPhotos { get; set; }
    public DbSet<HotelPhoto>? HotelPhotos { get; set; }
    public DbSet<User>? Users { get; set; }
    public DbSet<Hotel>? Hotels { get; set; }
    public DbSet<Room>? Rooms { get; set; }
    public DbSet<Reservation>? Reservations { get; set; }
    public DbSet<Feedback>? Feedbacks { get; set; }
}