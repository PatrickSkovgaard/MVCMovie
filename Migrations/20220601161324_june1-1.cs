using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MvcMovie.Migrations
{
    public partial class june11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b1ebef0c-d711-4e20-9acd-1b1b56d5d0f9", "AQAAAAEAACcQAAAAEDLvwqWfAWfqeTdxL2ISJZWtqAh/jSZLlz31DZB23iC2TsEkuPZ9Gv3O/zpOBY/tUw==", "f57a0dcd-d36f-41fa-b6d1-15f5be85094e" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "2",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "fa1e81d3-bcac-4747-ae95-fa69728d0f09", "AQAAAAEAACcQAAAAEO4C5jex3yBGJyRDLv5cew/wlJUdse7+Bn720uHXxYD2Vb8zh7WaQ0W1PQwSLO4X1A==", "352c6151-3e1b-4b89-bbac-e99163cfc905" });

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 3, 29, 616, DateTimeKind.Local).AddTicks(8976));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 3, 29, 616, DateTimeKind.Local).AddTicks(9029));

            migrationBuilder.UpdateData(
                table: "Movie",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2022, 6, 1, 18, 3, 29, 616, DateTimeKind.Local).AddTicks(9033));
        }
    }
}
