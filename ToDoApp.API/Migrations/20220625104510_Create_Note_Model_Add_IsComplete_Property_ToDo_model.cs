using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ToDoApp.API.Migrations
{
    public partial class Create_Note_Model_Add_IsComplete_Property_ToDo_model : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos");

            migrationBuilder.RenameTable(
                name: "ToDos",
                newName: "Notes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "Notes",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "Notes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsComplete",
                table: "Notes",
                type: "bit",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Notes",
                table: "Notes",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Notes",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "IsComplete",
                table: "Notes");

            migrationBuilder.RenameTable(
                name: "Notes",
                newName: "ToDos");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DueDate",
                table: "ToDos",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ToDos",
                table: "ToDos",
                column: "Id");
        }
    }
}
