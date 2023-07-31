using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.HasData
        (
            new User
            {
                Id = new Guid("3a08ecca-7fbe-4886-ad58-61998c01c9e0"),
                FirstName = "Alexander",
                LastName = "Valdaitsev",
                Email = "valdaitsevv@mail.ru",
                Password = "qweqwe",
                RoleId = new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab")
            },
            new User
            {
                Id = new Guid("a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9"),
                FirstName = "Katherine",
                LastName = "Vrublevskaya",
                Email = "katie@mail.ru",
                Password = "qweqwe",
                RoleId = new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab")
            },
            new User
            {
                Id = new Guid("f94a3937-8935-48a4-81f3-4d6e33603c65"),
                FirstName = "Default",
                LastName = "User",
                Email = "user@mail.ru",
                Password = "qweqwe",
                RoleId = new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab")
            },
            new User
            {
                Id = new Guid("eb8fd43e-aa3d-4bf2-bfac-b70af06668e9"),
                FirstName = "Admin",
                LastName = "Root",
                Email = "root@mail.ru",
                Password = "2233",
                RoleId = new Guid("3278235f-c470-4ba5-bc64-95a57739c8fc")
            }
        );
    }
}