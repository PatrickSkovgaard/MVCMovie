using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    public partial class june13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "2f3991c0-b77f-4cf3-83bb-5e71b10be78a", "AQAAAAEAACcQAAAAEGq0UgLyoEXrr0jFZ8WGg+ymYV7W4DJ7I2rReQtMNsXhYFa5cIWuxVp8BY/dpQP4pw==", "9b365161-ffbd-496c-b6ce-6f53b9673c1a" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "3aef49c4-67ae-47d9-bfe7-7bef55f3d5d1", "AQAAAAEAACcQAAAAELJVQgq3AWdLXczBUGrijT2v5SvcuVlboWKwcFFTsK+gnQyAF9OuKl2BBjAVndcmMg==", "0ef68274-3108-49f6-bf1e-7803abd47ab5" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 17, 54, 599, DateTimeKind.Local).AddTicks(9856));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 17, 54, 599, DateTimeKind.Local).AddTicks(9901));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 17, 54, 599, DateTimeKind.Local).AddTicks(9905));
        }
    }
}
