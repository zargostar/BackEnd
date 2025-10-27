using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class @new : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportStudent_Sports_SportsId",
                schema: "ordering",
                table: "SportStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SportStudent_Students_StudentsId",
                schema: "ordering",
                table: "SportStudent");

            migrationBuilder.DropTable(
                name: "SportStudents",
                schema: "ordering");

            migrationBuilder.RenameColumn(
                name: "StudentsId",
                schema: "ordering",
                table: "SportStudent",
                newName: "StudentId");

            migrationBuilder.RenameColumn(
                name: "SportsId",
                schema: "ordering",
                table: "SportStudent",
                newName: "SportId");

            migrationBuilder.RenameIndex(
                name: "IX_SportStudent_StudentsId",
                schema: "ordering",
                table: "SportStudent",
                newName: "IX_SportStudent_StudentId");

            migrationBuilder.AddColumn<short>(
                name: "SportLevel",
                schema: "ordering",
                table: "SportStudent",
                type: "smallint",
                nullable: false,
                defaultValue: (short)0);

            migrationBuilder.AddForeignKey(
                name: "FK_SportStudent_Sports_SportId",
                schema: "ordering",
                table: "SportStudent",
                column: "SportId",
                principalSchema: "ordering",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportStudent_Students_StudentId",
                schema: "ordering",
                table: "SportStudent",
                column: "StudentId",
                principalSchema: "ordering",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SportStudent_Sports_SportId",
                schema: "ordering",
                table: "SportStudent");

            migrationBuilder.DropForeignKey(
                name: "FK_SportStudent_Students_StudentId",
                schema: "ordering",
                table: "SportStudent");

            migrationBuilder.DropColumn(
                name: "SportLevel",
                schema: "ordering",
                table: "SportStudent");

            migrationBuilder.RenameColumn(
                name: "StudentId",
                schema: "ordering",
                table: "SportStudent",
                newName: "StudentsId");

            migrationBuilder.RenameColumn(
                name: "SportId",
                schema: "ordering",
                table: "SportStudent",
                newName: "SportsId");

            migrationBuilder.RenameIndex(
                name: "IX_SportStudent_StudentId",
                schema: "ordering",
                table: "SportStudent",
                newName: "IX_SportStudent_StudentsId");

            migrationBuilder.CreateTable(
                name: "SportStudents",
                schema: "ordering",
                columns: table => new
                {
                    SportId = table.Column<int>(type: "int", nullable: false),
                    StudentId = table.Column<int>(type: "int", nullable: false),
                    SportLevel = table.Column<short>(type: "smallint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SportStudents", x => new { x.SportId, x.StudentId });
                });

            migrationBuilder.AddForeignKey(
                name: "FK_SportStudent_Sports_SportsId",
                schema: "ordering",
                table: "SportStudent",
                column: "SportsId",
                principalSchema: "ordering",
                principalTable: "Sports",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SportStudent_Students_StudentsId",
                schema: "ordering",
                table: "SportStudent",
                column: "StudentsId",
                principalSchema: "ordering",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
