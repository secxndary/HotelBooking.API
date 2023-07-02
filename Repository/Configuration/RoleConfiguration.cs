using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class RoleConfiguration : IEntityTypeConfiguration<Role>
{
    public void Configure(EntityTypeBuilder<Role> builder)
    {
        builder.HasData
        (
            new Role
            {
                Id = new Guid("a7369ffa-71c9-4238-947c-f62c2faa32ab"),
                Name = "USER",
                Description = "Пользователь системы бронирования"
            },
            new Role
            {
                Id = new Guid("3278235f-c470-4ba5-bc64-95a57739c8fc"),
                Name = "ADMIN",
                Description = "Администратор программного средства"
            }
        );
    }
}
