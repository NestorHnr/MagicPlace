using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagicPlace_API.Migrations
{
    /// <inheritdoc />
    public partial class cambioNombre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_villas",
                table: "villas");

            migrationBuilder.RenameTable(
                name: "villas",
                newName: "Places");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Places",
                table: "Places",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Places",
                table: "Places");

            migrationBuilder.RenameTable(
                name: "Places",
                newName: "villas");

            migrationBuilder.AddPrimaryKey(
                name: "PK_villas",
                table: "villas",
                column: "Id");
        }
    }
}
