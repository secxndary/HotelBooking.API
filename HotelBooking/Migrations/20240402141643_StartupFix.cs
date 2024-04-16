using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HotelBooking.Migrations
{
    /// <inheritdoc />
    public partial class StartupFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
