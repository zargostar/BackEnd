using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class isActive : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Price",
                schema: "ordering",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                schema: "ordering",
                table: "AspNetUsers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsActive",
                schema: "ordering",
                table: "AspNetUsers");
        }
    }
}
