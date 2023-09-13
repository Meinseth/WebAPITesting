using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPITesting.Migrations
{
    /// <inheritdoc />
    public partial class moviePosition : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lenght",
                table: "Movies",
                newName: "Length");

            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Movies",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "Length",
                table: "Movies",
                newName: "Lenght");
        }
    }
}
