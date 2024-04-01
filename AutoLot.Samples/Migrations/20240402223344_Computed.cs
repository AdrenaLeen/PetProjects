using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLot.Samples.Migrations
{
    /// <inheritdoc />
    public partial class Computed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DateBuilt",
                schema: "public",
                table: "Inventory",
                type: "timestamp with time zone",
                nullable: false,
                defaultValueSql: "now()");

            migrationBuilder.AddColumn<bool>(
                name: "IsDriveable",
                schema: "public",
                table: "Inventory",
                type: "boolean",
                nullable: false,
                defaultValue: true);

            migrationBuilder.AddColumn<string>(
                name: "DisplayName",
                schema: "public",
                table: "Inventory",
                type: "text",
                nullable: false,
                computedColumnSql: "\"PetName\" || ' (' || \"Color\" || ')'",
                stored: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DisplayName",
                schema: "public",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "DateBuilt",
                schema: "public",
                table: "Inventory");

            migrationBuilder.DropColumn(
                name: "IsDriveable",
                schema: "public",
                table: "Inventory");
        }
    }
}
