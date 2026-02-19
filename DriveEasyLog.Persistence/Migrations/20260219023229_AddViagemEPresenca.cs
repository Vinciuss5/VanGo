using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveEasyLog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddViagemEPresenca : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PresencasDiarias_Alunos_AlunoId",
                table: "PresencasDiarias");

            migrationBuilder.DropForeignKey(
                name: "FK_PresencasDiarias_Viagens_ViagemId",
                table: "PresencasDiarias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PresencasDiarias",
                table: "PresencasDiarias");

            migrationBuilder.RenameTable(
                name: "PresencasDiarias",
                newName: "Presencas");

            migrationBuilder.RenameIndex(
                name: "IX_PresencasDiarias_ViagemId",
                table: "Presencas",
                newName: "IX_Presencas_ViagemId");

            migrationBuilder.RenameIndex(
                name: "IX_PresencasDiarias_AlunoId",
                table: "Presencas",
                newName: "IX_Presencas_AlunoId");

            migrationBuilder.AlterColumn<int>(
                name: "Periodo",
                table: "Viagens",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Pagamentos",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddColumn<DateTime>(
                name: "Confirmado",
                table: "Presencas",
                type: "TEXT",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Presencas",
                table: "Presencas",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Alunos_AlunoId",
                table: "Presencas",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Presencas_Viagens_ViagemId",
                table: "Presencas",
                column: "ViagemId",
                principalTable: "Viagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Alunos_AlunoId",
                table: "Presencas");

            migrationBuilder.DropForeignKey(
                name: "FK_Presencas_Viagens_ViagemId",
                table: "Presencas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Presencas",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "Confirmado",
                table: "Presencas");

            migrationBuilder.RenameTable(
                name: "Presencas",
                newName: "PresencasDiarias");

            migrationBuilder.RenameIndex(
                name: "IX_Presencas_ViagemId",
                table: "PresencasDiarias",
                newName: "IX_PresencasDiarias_ViagemId");

            migrationBuilder.RenameIndex(
                name: "IX_Presencas_AlunoId",
                table: "PresencasDiarias",
                newName: "IX_PresencasDiarias_AlunoId");

            migrationBuilder.AlterColumn<int>(
                name: "Periodo",
                table: "Viagens",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Pagamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_PresencasDiarias",
                table: "PresencasDiarias",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PresencasDiarias_Alunos_AlunoId",
                table: "PresencasDiarias",
                column: "AlunoId",
                principalTable: "Alunos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PresencasDiarias_Viagens_ViagemId",
                table: "PresencasDiarias",
                column: "ViagemId",
                principalTable: "Viagens",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
