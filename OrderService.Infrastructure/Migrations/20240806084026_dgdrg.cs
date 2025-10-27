using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrderService.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class dgdrg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_TempralOrder_OrderId",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TempralOrder",
                schema: "majid",
                table: "TempralOrder")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "PeriodEnd",
                schema: "majid",
                table: "TempralOrder")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.DropColumn(
                name: "PeriodStart",
                schema: "majid",
                table: "TempralOrder")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.RenameTable(
                name: "TempralOrder",
                schema: "majid",
                newName: "Orders",
                newSchema: "ordering")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid");

            migrationBuilder.RenameIndex(
                name: "IX_TempralOrder_UserId",
                schema: "ordering",
                table: "Orders",
                newName: "IX_Orders_UserId");

            migrationBuilder.AlterTable(
                name: "Orders",
                schema: "ordering")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<string>(
                name: "Address_HomeAddresses_City",
                schema: "ordering",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_HomeAddresses_PostalCode",
                schema: "ordering",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_HomeAddresses_Street",
                schema: "ordering",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_WorkAddresses_City",
                schema: "ordering",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_WorkAddresses_PostalCode",
                schema: "ordering",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Address_WorkAddresses_Street",
                schema: "ordering",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "ordering",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<string>(
                name: "Moblie",
                schema: "ordering",
                table: "Orders",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "ordering",
                table: "Orders",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "ordering",
                table: "Orders",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150)
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "ordering",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:Identity", "1, 1")
                .OldAnnotation("SqlServer:IsTemporal", true)
                .OldAnnotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .OldAnnotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .OldAnnotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .OldAnnotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                schema: "ordering",
                table: "Orders",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "ordering",
                table: "OrderItems",
                column: "OrderId",
                principalSchema: "ordering",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Orders_OrderId",
                schema: "ordering",
                table: "OrderItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                schema: "ordering",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Address_HomeAddresses_City",
                schema: "ordering",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_HomeAddresses_PostalCode",
                schema: "ordering",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_HomeAddresses_Street",
                schema: "ordering",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_WorkAddresses_City",
                schema: "ordering",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_WorkAddresses_PostalCode",
                schema: "ordering",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Address_WorkAddresses_Street",
                schema: "ordering",
                table: "AspNetUsers");

            migrationBuilder.EnsureSchema(
                name: "majid");

            migrationBuilder.RenameTable(
                name: "Orders",
                schema: "ordering",
                newName: "TempralOrder",
                newSchema: "majid");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_UserId",
                schema: "majid",
                table: "TempralOrder",
                newName: "IX_TempralOrder_UserId");

            migrationBuilder.AlterTable(
                name: "TempralOrder",
                schema: "majid")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<string>(
                name: "UserId",
                schema: "majid",
                table: "TempralOrder",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<string>(
                name: "Moblie",
                schema: "majid",
                table: "TempralOrder",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<string>(
                name: "FullName",
                schema: "majid",
                table: "TempralOrder",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<string>(
                name: "Address",
                schema: "majid",
                table: "TempralOrder",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(150)",
                oldMaxLength: 150)
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                schema: "majid",
                table: "TempralOrder",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1")
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodEnd",
                schema: "majid",
                table: "TempralOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddColumn<DateTime>(
                name: "PeriodStart",
                schema: "majid",
                table: "TempralOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                .Annotation("SqlServer:IsTemporal", true)
                .Annotation("SqlServer:TemporalHistoryTableName", "TempralOrderHistory")
                .Annotation("SqlServer:TemporalHistoryTableSchema", "majid")
                .Annotation("SqlServer:TemporalPeriodEndColumnName", "PeriodEnd")
                .Annotation("SqlServer:TemporalPeriodStartColumnName", "PeriodStart");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TempralOrder",
                schema: "majid",
                table: "TempralOrder",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_TempralOrder_OrderId",
                schema: "ordering",
                table: "OrderItems",
                column: "OrderId",
                principalSchema: "majid",
                principalTable: "TempralOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
