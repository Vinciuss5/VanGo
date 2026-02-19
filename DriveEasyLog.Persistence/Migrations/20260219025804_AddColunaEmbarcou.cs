using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DriveEasyLog.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddColunaEmbarcou : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Embarcou",
                table: "Presencas",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "HorarioEmbarque",
                table: "Presencas",
                type: "TEXT",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Embarcou",
                table: "Presencas");

            migrationBuilder.DropColumn(
                name: "HorarioEmbarque",
                table: "Presencas");
        }
    }
}
