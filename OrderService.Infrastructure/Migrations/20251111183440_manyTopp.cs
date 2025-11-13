using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class manyTopp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SuplierId",
                schema: "ordering",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Supliers",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Supliers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_SuplierId",
                schema: "ordering",
                table: "Products",
                column: "SuplierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products",
                column: "SuplierId",
                principalSchema: "ordering",
                principalTable: "Supliers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Supliers_SuplierId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Supliers",
                schema: "ordering");

            migrationBuilder.DropIndex(
                name: "IX_Products_SuplierId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "SuplierId",
                schema: "ordering",
                table: "Products");
        }
    }
}
