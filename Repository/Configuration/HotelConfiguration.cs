using Entities.Models.UserModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace Repository.Configuration;

public class HotelConfiguration : IEntityTypeConfiguration<Hotel>
{
    public void Configure(EntityTypeBuilder<Hotel> builder)
    {
        builder.HasData
        (
            new Hotel
            {
                Id = new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                Name = "President Hotel",
                Stars = 5,
                Description = "Президентский отель Премиум-класса",
                Address = "Беларусь, г. Минск, пл. Ленина, д. 101",
                HotelOwnerId = "c459163f-341b-4073-a7b7-067c1ceeac15" 
            },
            new Hotel
            {
                Id = new Guid("f934d940-f542-400b-8182-aea42a9b0773"),
                Name = "Турист",
                Stars = 3,
                Description = "Дефолтный 3-звездочный отель",
                Address = "Беларусь, г. Минск, ул. Владислава Гоулбка, д. 14",
                HotelOwnerId = "ed3707a2-a416-4318-95a6-e462b10e9936"
            },
            new Hotel
            {
                Id = new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"),
                Name = "Беларусь",
                Stars = 4,
                Description = "Для настоящих патриотов",
                Address = "Беларусь, г. Минск, пл. Октябрьской Революции, д. 88",
                HotelOwnerId = "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6" 
            },
            new Hotel
            {
                Id = new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"),
                Name = "Поляна",
                Stars = 2,
                Description = "Лесное убежище",
                Address = "Беларусь, п.г.т. Заречище, ул. Дубравная, д. 13",
                HotelOwnerId = "42e40179-1f6c-41b7-be2f-754023e576fa"
            }
        );
    }
}
