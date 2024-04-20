using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddConfirmedByAdminToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HotelOwnerConfirmedByAdmin",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "11204274-8465-45ec-8430-65b29e64d2f7", true, "e4888f0d-8cbe-452b-873b-34ad470b7ba2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "28d47a36-803c-49f8-9319-2df55d9af377", true, "5fa54087-39a3-45ee-aa63-0cec5c46e5f5" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "833678bc-6810-4c14-ab5b-f7d78d00433d", true, "2bc6c6fa-fe0a-4e78-9428-154cc28ceb8c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "ca308b01-b735-4ada-9336-49dd847539b8", true, "b0850bcd-f2c7-417e-b403-2e08b90f904c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "75c8fdf1-18a0-4c0d-a6c1-97a6f4c58783", true, "089e5fac-5983-4089-b8cd-baf24ba2d1c2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "e98a9a30-94d2-4ab3-beb4-1a6c85bc15ec", true, "a21ee8f4-2e60-4cb0-9e74-27d7ec510b23" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "614f9336-f591-4b01-b92e-7c4fb0df614f", true, "53623b8b-63c6-476c-9784-74e4e039d455" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "acbddcae-062b-4b89-be2a-f3595ba1a4ab", true, "34fe7d29-4601-404a-b718-ba092312aa4f" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "78c7ef06-4311-42d4-81d1-17c1f3552751", true, "868be0c7-15bb-4845-8613-80fba8ae9ffc" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "HotelOwnerConfirmedByAdmin", "SecurityStamp" },
                values: new object[] { "31b3f843-5e6d-43aa-9c5f-9d6c82959595", true, "293ed81e-8a7c-41d8-8749-3d933aa04113" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HotelOwnerConfirmedByAdmin",
                table: "AspNetUsers");

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
        }
    }
}
