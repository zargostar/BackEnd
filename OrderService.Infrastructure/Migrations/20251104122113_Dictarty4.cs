using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Dictarty4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location_Latitude",
                schema: "ordering",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Location_Longitude",
                schema: "ordering",
                table: "Actors");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "ordering",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                schema: "ordering",
                table: "Actors");

            migrationBuilder.AddColumn<double>(
                name: "Location_Latitude",
                schema: "ordering",
                table: "Actors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Location_Longitude",
                schema: "ordering",
                table: "Actors",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
