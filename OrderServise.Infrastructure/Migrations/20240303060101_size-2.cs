using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderServise.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class size2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Key",
                schema: "ordering",
                table: "Sizes");

            migrationBuilder.RenameColumn(
                name: "Value",
                schema: "ordering",
                table: "Sizes",
                newName: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                schema: "ordering",
                table: "Sizes",
                newName: "Value");

            migrationBuilder.AddColumn<string>(
                name: "Key",
                schema: "ordering",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
