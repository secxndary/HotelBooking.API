using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Repository.Configuration;
namespace Repository;

public class RepositoryContext : DbContext
{
    public RepositoryContext(DbContextOptions options) 
        : base (options)
    { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfiguration(new RoleConfiguration())
            .ApplyConfiguration(new UserConfiguration())
            .ApplyConfiguration(new RoomTypeConfiguration())
            .ApplyConfiguration(new RoomConfiguration())
            .ApplyConfiguration(new HotelConfiguration())
            .ApplyConfiguration(new ReservationConfiguration())
            .ApplyConfiguration(new FeedbackConfiguration())
            .ApplyConfiguration(new RoomPhotoConfiguration())
            .ApplyConfiguration(new HotelPhotoConfiguration());
    }

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