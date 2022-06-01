using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    public partial class june14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "8ffdb8c6-3d48-4b3a-b50e-5f0904ccc9e0", "AQAAAAEAACcQAAAAEA7O1P30cU1PLkD5uscW1bbSJpiLrK9vAbzHD+y3up1b1ZY5/90V+F5nK+2focfIbQ==", "f152769c-62ea-4a13-b7ae-66be169cb1a1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "374dab4a-a962-41a9-af4e-232fa11dc423", "AQAAAAEAACcQAAAAENrJhVkdTtXpeIssiIfBK1k9bUTt0xLE+paJMZ2qP+lC31g62UxH/d23E68t2IZu5A==", "a363e59f-45a8-4ec7-a63c-3ee612a85454" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 47, 16, 576, DateTimeKind.Local).AddTicks(1954));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 47, 16, 576, DateTimeKind.Local).AddTicks(2015));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 47, 16, 576, DateTimeKind.Local).AddTicks(2019));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "46121d63-b6c4-4fa7-a318-e1acf6ba8ef5", "AQAAAAEAACcQAAAAEO5EcOvb2o0P7UmG3oSHYlKcD1pQT7meRFOpaIxvbIN9abq3oMSQ7kP5a1aGRAfhqw==", "dca48214-8ba8-4b23-8774-f157b4094d07" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "abeafbd2-24a5-426d-b875-bce48c5263c5", "AQAAAAEAACcQAAAAEApPGe9X4yJyEQZkA+I8PAGvyzQcwDkx1lkqF6E5hSi72L3kSsQxOAMeMhX3gfXrCA==", "7c44a701-14b1-4857-b728-dbc3b9036a0e" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 25, 29, 509, DateTimeKind.Local).AddTicks(9194));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 25, 29, 509, DateTimeKind.Local).AddTicks(9243));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 25, 29, 509, DateTimeKind.Local).AddTicks(9247));
        }
    }
}
