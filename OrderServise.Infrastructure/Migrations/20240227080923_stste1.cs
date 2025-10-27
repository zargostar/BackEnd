using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class stste1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StateId",
                schema: "ordering",
                table: "Cities",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cities_StateId",
                schema: "ordering",
                table: "Cities",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cities_States_StateId",
                schema: "ordering",
                table: "Cities",
                column: "StateId",
                principalSchema: "ordering",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cities_States_StateId",
                schema: "ordering",
                table: "Cities");

            migrationBuilder.DropIndex(
                name: "IX_Cities_StateId",
                schema: "ordering",
                table: "Cities");

            migrationBuilder.DropColumn(
                name: "StateId",
                schema: "ordering",
                table: "Cities");
        }
    }
}
