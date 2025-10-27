using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ddddd : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "ordering",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                schema: "ordering",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Customer",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OrderTest",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contents = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    BillingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BillingAddress_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BillingAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Line1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ShippingAddress_Line2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ShippingAddress_PostCode = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderTest", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderTest_Customer_CustomerId",
                        column: x => x.CustomerId,
                        principalSchema: "ordering",
                        principalTable: "Customer",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                schema: "ordering",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_OrderTest_CustomerId",
                schema: "ordering",
                table: "OrderTest",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customer_CustomerId",
                schema: "ordering",
                table: "Orders",
                column: "CustomerId",
                principalSchema: "ordering",
                principalTable: "Customer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customer_CustomerId",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "OrderTest",
                schema: "ordering");

            migrationBuilder.DropTable(
                name: "Customer",
                schema: "ordering");

            migrationBuilder.DropIndex(
                name: "IX_Orders_CustomerId",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "ordering",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
