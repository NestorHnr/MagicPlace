using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPlace_API.Migrations
{
    /// <inheritdoc />
    public partial class AlimentarTablaPlace : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Places",
                columns: new[] { "Id", "Cost", "DateCreate", "DateUpdate", "Detail", "ImageUrl", "Name", "Ocupants", "Service", "SquareMeters" },
                values: new object[] { 1, 5.0, new DateTime(2023, 5, 6, 7, 1, 23, 211, DateTimeKind.Local).AddTicks(1143), new DateTime(2023, 5, 6, 7, 1, 23, 211, DateTimeKind.Local).AddTicks(1154), "test", "test", "Test", 5, "", 5 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
