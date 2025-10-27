using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class addstate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Cities_CityId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropTable(
                name: "Cities",
                schema: "ordering");

            migrationBuilder.DropIndex(
                name: "IX_Products_CityId",
                schema: "ordering",
                table: "Products");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                schema: "ordering",
                table: "States",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_States_StateId",
                schema: "ordering",
                table: "States",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_States_States_StateId",
                schema: "ordering",
                table: "States",
                column: "StateId",
                principalSchema: "ordering",
                principalTable: "States",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_States_States_StateId",
                schema: "ordering",
                table: "States");

            migrationBuilder.DropIndex(
                name: "IX_States_StateId",
                schema: "ordering",
                table: "States");

            migrationBuilder.DropColumn(
                name: "StateId",
                schema: "ordering",
                table: "States");

            migrationBuilder.CreateTable(
                name: "Cities",
                schema: "ordering",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                });

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
    }
}
