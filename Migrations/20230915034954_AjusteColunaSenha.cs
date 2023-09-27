using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GerenciamentoDeTarefas.Migrations
{
    /// <inheritdoc />
    public partial class AjusteColunaSenha : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "VARCHAR",
                table: "User",
                newName: "Password");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 15, 0, 49, 54, 21, DateTimeKind.Local).AddTicks(8340),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 9, 13, 23, 21, 17, 527, DateTimeKind.Local).AddTicks(8606));

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "User",
                type: "VARCHAR(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Tarefa",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 15, 0, 49, 54, 23, DateTimeKind.Local).AddTicks(1479),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 9, 13, 23, 21, 17, 529, DateTimeKind.Local).AddTicks(1398));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Password",
                table: "User",
                newName: "VARCHAR");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "User",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 13, 23, 21, 17, 527, DateTimeKind.Local).AddTicks(8606),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 9, 15, 0, 49, 54, 21, DateTimeKind.Local).AddTicks(8340));

            migrationBuilder.AlterColumn<string>(
                name: "VARCHAR",
                table: "User",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreateDate",
                table: "Tarefa",
                type: "DATETIME",
                nullable: false,
                defaultValue: new DateTime(2023, 9, 13, 23, 21, 17, 529, DateTimeKind.Local).AddTicks(1398),
                oldClrType: typeof(DateTime),
                oldType: "DATETIME",
                oldDefaultValue: new DateTime(2023, 9, 15, 0, 49, 54, 23, DateTimeKind.Local).AddTicks(1479));
        }
    }
}
