using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class r1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Theaters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Theaters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Theaters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Theaters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Students",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Students",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "States",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "States",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Sports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Sports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Sports",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Sports",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Skills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Skills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Skills",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Skills",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Sizes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Sizes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Sizes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Sizes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Resumes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Resumes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Resumes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Resumes",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Products",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Products",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Orders",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "OrderItems",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "OrderItems",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Movies",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Movies",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Genres",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Genres",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Features",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Features",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                schema: "ordering",
                table: "Actors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<TimeSpan>(
                name: "Delay",
                schema: "ordering",
                table: "Actors",
                type: "time",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));

            migrationBuilder.AddColumn<DateTime>(
                name: "DeletedAt",
                schema: "ordering",
                table: "Actors",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DeletedBy",
                schema: "ordering",
                table: "Actors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Actors",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Theaters");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Theaters");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Theaters");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Theaters");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Students");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "States");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "States");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "States");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "States");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Sports");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Sizes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Resumes");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Genres");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Features");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                schema: "ordering",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "Delay",
                schema: "ordering",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "DeletedAt",
                schema: "ordering",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "DeletedBy",
                schema: "ordering",
                table: "Actors");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                schema: "ordering",
                table: "Actors");
        }
    }
}
