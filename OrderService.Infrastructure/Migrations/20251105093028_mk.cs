using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class mk : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Count",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "FactoryId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "MetaData",
                schema: "ordering",
                table: "Products");

            migrationBuilder.AddColumn<long>(
                name: "InStock",
                schema: "ordering",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InStock",
                schema: "ordering",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "CityId",
                schema: "ordering",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Count",
                schema: "ordering",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "FactoryId",
                schema: "ordering",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "MetaData",
                schema: "ordering",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
