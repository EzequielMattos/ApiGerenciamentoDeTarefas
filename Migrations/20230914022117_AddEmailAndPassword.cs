using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AddEmailAndPassword : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 13, 23, 21, 17, 527, DateTimeKind.Local).AddTicks(8606),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 9, 12, 23, 50, 19, 283, DateTimeKind.Local).AddTicks(3548));

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "VARCHAR",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Tarefa",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 13, 23, 21, 17, 529, DateTimeKind.Local).AddTicks(1398),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 9, 12, 23, 50, 19, 284, DateTimeKind.Local).AddTicks(5768));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "VARCHAR",
                table: "User");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 23, 50, 19, 283, DateTimeKind.Local).AddTicks(3548),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 9, 13, 23, 21, 17, 527, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Tarefa",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 12, 23, 50, 19, 284, DateTimeKind.Local).AddTicks(5768),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 9, 13, 23, 21, 17, 529, DateTimeKind.Local).AddTicks(1398));
        }
    }
}
