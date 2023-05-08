using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPlace_API.Migrations
{
    /// <inheritdoc />
    public partial class CreateTableUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Names = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rol = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2023, 5, 7, 21, 20, 23, 188, DateTimeKind.Local).AddTicks(3492), new DateTime(2023, 5, 7, 21, 20, 23, 188, DateTimeKind.Local).AddTicks(3509) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2023, 5, 6, 15, 37, 22, 687, DateTimeKind.Local).AddTicks(3098), new DateTime(2023, 5, 6, 15, 37, 22, 687, DateTimeKind.Local).AddTicks(3110) });
        }
    }
}
