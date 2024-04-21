using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddHotelOwnerDeclinedByAdmin : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HotelOwnerDeclinedByAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "5c742d38-3010-4fb8-b2d5-80ee2e076d76", false, "7f2eed68-f4df-4c1a-aa7e-dabb0d447e51" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "f755f384-9c99-4c2d-8681-3548a19f5612", false, "ebb2f89b-942f-44fa-b11d-8f67d9e58d1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "2bb2500c-ddfe-42a1-8a3e-c7078b376067", false, "9ca2dd0d-ea34-4767-b922-e47b208a4b1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "a7558e74-9a84-49df-a02e-94050426dbca", false, "058e8df2-3427-4a5b-b002-36875d1f4ecf" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "08bc997f-def9-4a00-bc5a-02f7fa7eebd6", false, "0f0b93b5-6f4a-4451-849c-ac6da2cb3a94" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "16cfcb63-51f6-4432-b23f-2e8ea27e4d96", false, "568b26fc-9249-47ff-ac3d-248ff8c6cccb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "4bed7836-3ec3-4c39-aa7f-5ba7eb45187b", false, "85756666-c13c-41b7-912b-3a3563ee2a01" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "5b5f1b7b-a846-41a1-aa50-a7820b71e42c", false, "3c11be16-bb05-4527-af3a-421ac25bc7db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "38348ddb-eb9a-4e1c-89c5-05ce27a66acc", false, "b302a937-b598-48fd-a46c-22210ddee685" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerDeclinedByAdmin", "SecurityStamp" },
                values: new object[] { "9524348c-7373-48aa-b406-d4bc1e907d5e", false, "a830796d-86c5-4eb5-8e49-9d41dc9c6412" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelOwnerDeclinedByAdmin",
                table: "AspNetUsers");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "11204274-8465-45ec-8430-65b29e64d2f7", "e4888f0d-8cbe-452b-873b-34ad470b7ba2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "28d47a36-803c-49f8-9319-2df55d9af377", "5fa54087-39a3-45ee-aa63-0cec5c46e5f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "833678bc-6810-4c14-ab5b-f7d78d00433d", "2bc6c6fa-fe0a-4e78-9428-154cc28ceb8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "ca308b01-b735-4ada-9336-49dd847539b8", "b0850bcd-f2c7-417e-b403-2e08b90f904c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "75c8fdf1-18a0-4c0d-a6c1-97a6f4c58783", "089e5fac-5983-4089-b8cd-baf24ba2d1c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "e98a9a30-94d2-4ab3-beb4-1a6c85bc15ec", "a21ee8f4-2e60-4cb0-9e74-27d7ec510b23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "614f9336-f591-4b01-b92e-7c4fb0df614f", "53623b8b-63c6-476c-9784-74e4e039d455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "acbddcae-062b-4b89-be2a-f3595ba1a4ab", "34fe7d29-4601-404a-b718-ba092312aa4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "78c7ef06-4311-42d4-81d1-17c1f3552751", "868be0c7-15bb-4845-8613-80fba8ae9ffc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "31b3f843-5e6d-43aa-9c5f-9d6c82959595", "293ed81e-8a7c-41d8-8749-3d933aa04113" });
        }
    }
}
