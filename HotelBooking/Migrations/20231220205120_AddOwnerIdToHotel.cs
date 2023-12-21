using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class AddOwnerIdToHotel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HotelOwnerId",
                table: "Hotels",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b0c8882a-d430-412c-9447-c36c7581b4b2", "1ea4240e-3580-4531-8e50-90fedd6e6448" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "89900690-aa76-4cc2-9e61-b8d19fe0ce2d", "51860717-297d-45cc-b4d4-882d3a2c566e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6b8abd97-d015-4928-a43d-500af9b8c77c", "108fecd3-3785-4c37-aae1-24dda4cfc50e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "58c3bee9-75b1-4c0b-b9ba-5fa1c0620c2a", "452cba5f-9d72-4eed-a89b-ebc46ef94889" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7586a883-ad5e-4b7a-8a87-c851fbbec528", "7d6f8567-ca2c-4abc-9b91-cae873620fa2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a37118b2-0282-41f3-9b29-5d9aff0a1b12", "b9489ab6-b08b-43df-8d50-d481fd0e1fd4" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "21a05ebf-877d-43b5-86f3-f87f45662caf", "862c276c-5afa-449f-970e-a98d6ad8aca2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "b6daa7cc-0f0b-4e9c-9b21-bec6a9dce295", "09bd4cee-273a-4bf3-b18d-11bd2f4b7830" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a59dde5f-187a-4813-8fa3-e065ae53aab9", "994e2509-22db-4625-924f-1ce3d0cfc0ac" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "8e259bc4-517b-464a-bd15-2b77719df834", "2205fc18-e515-442a-90da-3ab89850a35b" });

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("0c6cc6d4-3f8c-43d2-9591-230cb646aab9"),
                column: "HotelOwnerId",
                value: "42e40179-1f6c-41b7-be2f-754023e576fa");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("894622e4-9303-4ee8-a25b-dbea1c26eb1a"),
                column: "HotelOwnerId",
                value: "c459163f-341b-4073-a7b7-067c1ceeac15");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("e418aacc-8a7c-4d78-b509-24dd42e823ee"),
                column: "HotelOwnerId",
                value: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6");

            migrationBuilder.UpdateData(
                table: "Hotels",
                keyColumn: "Id",
                keyValue: new Guid("f934d940-f542-400b-8182-aea42a9b0773"),
                column: "HotelOwnerId",
                value: "ed3707a2-a416-4318-95a6-e462b10e9936");

            migrationBuilder.CreateIndex(
                name: "IX_Hotels_HotelOwnerId",
                table: "Hotels",
                column: "HotelOwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Hotels_AspNetUsers_HotelOwnerId",
                table: "Hotels",
                column: "HotelOwnerId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Hotels_AspNetUsers_HotelOwnerId",
                table: "Hotels");

            migrationBuilder.DropIndex(
                name: "IX_Hotels_HotelOwnerId",
                table: "Hotels");

            migrationBuilder.DropColumn(
                name: "HotelOwnerId",
                table: "Hotels");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1567fa9b-7fc8-4f4f-b4df-896397616bfe",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "de2a4f87-8730-4262-91ff-1ef1980c5412", "93d84a39-3e7c-439e-8b57-9761aab170ce" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "27bc938b-a6b3-4c8e-ba6b-74ddadb424ed",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c5f71539-e810-4a36-9fbb-80b3827d0c39", "67d21d8b-b85d-4f6a-afb4-d478381305db" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "3a08ecca-7fbe-4886-ad58-61998c01c9e0",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "67f9092c-beb2-4c53-8d9b-f6d4dca1bd0c", "e79eae36-e050-4cee-ba69-a99c2f9faff3" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "42e40179-1f6c-41b7-be2f-754023e576fa",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "7c27141a-f862-491b-9c67-c45336ed160e", "b4868afa-831d-4148-b29a-424704f33230" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "a3c2b7a1-6c0e-4fa0-b3bd-ed1d2c428cf9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "3b8de0a4-5bdc-4646-88df-698e5371c596", "d53583a7-9ab7-46f4-bfda-bb8173ee581d" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ba8fe5c0-0c4e-49c0-b12e-5dd834b6e8d6",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "6becbc76-0578-46b8-9ddc-43829e5f8518", "aa90c840-9131-485e-85d6-56d34dd89a73" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "c459163f-341b-4073-a7b7-067c1ceeac15",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "a690981f-5136-4c73-80c6-2e48a35b7ed5", "98f8ec12-f6fc-427b-bcf2-f24bad1a6b80" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "eb8fd43e-aa3d-4bf2-bfac-b70af06668e9",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "c8ba9e9e-a42f-4372-bc57-bf0a068a6453", "b88056ab-365d-41df-8529-b710a51ec5d2" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "ed3707a2-a416-4318-95a6-e462b10e9936",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "616705f7-b2b0-4fca-908c-9b46703dfc75", "10511b01-ce6d-4820-9ea2-fe4422e3200a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f94a3937-8935-48a4-81f3-4d6e33603c65",
                columns: new[] { "ConcurrencyStamp", "SecurityStamp" },
                values: new object[] { "2a3a56bd-f48a-4367-afc0-0984a05827fd", "39a61a17-123c-4dd2-b8ef-6a7bc2dc7e32" });
        }
    }
}
