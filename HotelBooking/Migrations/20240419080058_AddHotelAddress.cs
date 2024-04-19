using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddHotelAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Hotels",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7222a745-3778-4b71-910d-4ce41b8ab273", "a19c5498-2785-4700-97b9-6c3ff974d7e8" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a29072d9-a58d-473f-b1e2-16a81d74a334", "70e08d11-4bb3-4030-a657-05d8b5938fb4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a3ef6cd6-5ee8-4378-b10f-66e434612ff9", "2c2f2240-1b02-41da-9745-1258e4b7a147" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "26258259-a7f4-4417-b554-8db16fb21615", "4cf5dd5c-99ac-4f09-b827-10a776bbaee0" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "02a80348-6c9a-46c7-b8c2-fc627d93182c", "a2cecd2a-6527-4bf8-b1a5-5cc669ccef01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "1d0c5139-a95f-4fa3-9205-b7df2f522b95", "2a6c7549-5c58-46c4-8a04-2291ba222af4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "d8f59ef4-07e4-42da-bf51-0e11a9980258", "8ff7dc6a-a7a7-4bae-b6e5-eff72f2dbd57" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "12b7a0d4-4f50-4b62-b486-f8065a2f1001", "70ab67b8-d3fa-4f85-b336-7282274883e4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4f9045f8-14af-4246-8abc-d7782eba89cb", "4750d0fa-1634-42df-aec3-00a7b93012d5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7f1aa18d-4d22-465d-87d6-4bad725cd3d4", "be880824-41c1-486d-85e1-4403102baaa5" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"),
                column: "Address",
                value: "Беларусь, п.г.т. Заречище, ул. Дубравная, д. 13");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                column: "Address",
                value: "Беларусь, г. Минск, пл. Ленина, д. 101");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"),
                column: "Address",
                value: "Беларусь, г. Минск, пл. Октябрьской Революции, д. 88");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("f934d940-f542-400b-8182-aea42a9b0773"),
                column: "Address",
                value: "Беларусь, г. Минск, ул. Владислава Гоулбка, д. 14");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "749815f0-e73c-4047-bdf8-a3f238c3a46f", "2db5048b-e674-4b55-83d5-017313961efa" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "726a23b9-b851-488f-8e03-360afa40f668", "15ac7ebe-7af0-40ed-a820-d8bf278e2418" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21790904-a7c5-461f-936f-f3bd7afd2c85", "e320f2fd-0ddf-4c8d-b408-9a11e1861f63" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "acbd5eac-4fc8-4baa-8b3c-e2436020c407", "3bf27f8d-d6e5-424a-924e-651e07b35a82" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "4337ce0f-9360-4485-8ab2-bc511cf25a8a", "12d35f0f-0066-40a9-bde9-971acfa7238b" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8e05286-2c98-4479-b579-422656c12e96", "b6c3569f-70ca-412d-9a75-806360504799" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "eef8a03e-a786-4480-a446-5fc25aad4d99", "c16c161e-7534-4a59-a93f-62f7722a38f6" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78005709-c221-4e20-9b1b-001dbc50e7eb", "8fdda588-7c21-4f0f-b0ca-c66982d1cb73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a9ec56c8-741e-48ea-b34f-c0e12941fdd0", "ff8ddfac-8826-464d-920f-04ffe856f679" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "cddb3af3-2173-4dfb-98ba-82ca4ff79ae0", "c73930d4-f3fa-4b07-8324-9b71f04eddcc" });
        }
    }
}
