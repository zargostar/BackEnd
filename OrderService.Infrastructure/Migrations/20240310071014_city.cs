using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class city : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CityId",
                schema: "ordering",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SubCategoryId",
                schema: "ordering",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CityId",
                schema: "ordering",
                table: "Products",
                column: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Cities_CityId",
                schema: "ordering",
                table: "Products",
                column: "CityId",
                principalSchema: "ordering",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cities_CityId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_CityId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CityId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SubCategoryId",
                schema: "ordering",
                table: "Products");
        }
    }
}
