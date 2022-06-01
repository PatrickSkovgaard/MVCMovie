using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    public partial class june12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "36e9d6e7-3ae3-4845-a1af-2d890b9fe4f5", "AQAAAAEAACcQAAAAECTZxbIHcRGRK9R19vl+vGGufYy5oqGRSTI54OsaGAs/rChPcPRKpLXxhjGiWXrYOw==", "a4de288f-dce0-4416-a5cc-6fd82bd5203c" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "f674793e-bca8-412d-9e81-5300c2e5c516", "AQAAAAEAACcQAAAAEC+6BS/XKbStAlVt57eDTaxfBu9Jrr/06uPs99saOHRo9bRQvftu81x9I4ZP6vIZqQ==", "24041b3f-32d2-44d9-ad53-76885f84b6d8" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 13, 23, 855, DateTimeKind.Local).AddTicks(5021));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 13, 23, 855, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 13, 23, 855, DateTimeKind.Local).AddTicks(5076));
        }
    }
}
