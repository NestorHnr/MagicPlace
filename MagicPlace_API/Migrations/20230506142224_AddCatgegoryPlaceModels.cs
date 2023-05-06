using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPlace_API.Migrations
{
    /// <inheritdoc />
    public partial class AddCatgegoryPlaceModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriesPlaces",
                columns: table => new
                {
                    NuCategory = table.Column<int>(type: "int", nullable: false),
                    PlaceId = table.Column<int>(type: "int", nullable: false),
                    SpecialDetails = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdateTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriesPlaces", x => x.NuCategory);
                    table.ForeignKey(
                        name: "FK_CategoriesPlaces_Places_PlaceId",
                        column: x => x.PlaceId,
                        principalTable: "Places",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2023, 5, 6, 9, 22, 24, 401, DateTimeKind.Local).AddTicks(9941), new DateTime(2023, 5, 6, 9, 22, 24, 401, DateTimeKind.Local).AddTicks(9955) });

            migrationBuilder.CreateIndex(
                name: "IX_CategoriesPlaces_PlaceId",
                table: "CategoriesPlaces",
                column: "PlaceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CategoriesPlaces");

            migrationBuilder.UpdateData(
                table: "Places",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreate", "DateUpdate" },
                values: new object[] { new DateTime(2023, 5, 6, 7, 1, 23, 211, DateTimeKind.Local).AddTicks(1143), new DateTime(2023, 5, 6, 7, 1, 23, 211, DateTimeKind.Local).AddTicks(1154) });
        }
    }
}
