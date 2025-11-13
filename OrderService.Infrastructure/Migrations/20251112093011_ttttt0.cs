using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ttttt0 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "ordering",
                table: "Supliers",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "ordering",
                table: "Supliers",
                type: "nvarchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products",
                column: "SuplierId",
                principalSchema: "ordering",
                principalTable: "Supliers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                schema: "ordering",
                table: "Supliers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Country",
                schema: "ordering",
                table: "Supliers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)");

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
    }
}
