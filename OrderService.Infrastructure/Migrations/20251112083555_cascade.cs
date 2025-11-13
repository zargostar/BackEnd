using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class cascade : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products",
                column: "SuplierId",
                principalSchema: "ordering",
                principalTable: "Supliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products",
                column: "SuplierId",
                principalSchema: "ordering",
                principalTable: "Supliers",
                principalColumn: "Id");
        }
    }
}
