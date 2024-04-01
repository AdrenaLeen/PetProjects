using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLot.Samples.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTimeStamp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDriver_Cars_CarsId",
                table: "CarDriver");

            migrationBuilder.DropForeignKey(
                name: "FK_Cars_Makes_MakeId",
                table: "Cars");

            migrationBuilder.DropForeignKey(
                name: "FK_Radios_Cars_CarId",
                table: "Radios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cars",
                table: "Cars");

            migrationBuilder.EnsureSchema(
                name: "public");

            migrationBuilder.RenameTable(
                name: "Cars",
                newName: "Inventory",
                newSchema: "public");

            migrationBuilder.RenameIndex(
                name: "IX_Cars_MakeId",
                schema: "public",
                table: "Inventory",
                newName: "IX_Inventory_MakeId");

            migrationBuilder.AlterColumn<string>(
                name: "PetName",
                schema: "public",
                table: "Inventory",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                schema: "public",
                table: "Inventory",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inventory",
                schema: "public",
                table: "Inventory",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriver_Inventory_CarsId",
                table: "CarDriver",
                column: "CarsId",
                principalSchema: "public",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Makes_MakeId",
                schema: "public",
                table: "Inventory",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Radios_Inventory_CarId",
                table: "Radios",
                column: "CarId",
                principalSchema: "public",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDriver_Inventory_CarsId",
                table: "CarDriver");

            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Makes_MakeId",
                schema: "public",
                table: "Inventory");

            migrationBuilder.DropForeignKey(
                name: "FK_Radios_Inventory_CarId",
                table: "Radios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inventory",
                schema: "public",
                table: "Inventory");

            migrationBuilder.RenameTable(
                name: "Inventory",
                schema: "public",
                newName: "Cars");

            migrationBuilder.RenameIndex(
                name: "IX_Inventory_MakeId",
                table: "Cars",
                newName: "IX_Cars_MakeId");

            migrationBuilder.AlterColumn<string>(
                name: "PetName",
                table: "Cars",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Color",
                table: "Cars",
                type: "text",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "character varying(50)",
                oldMaxLength: 50);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cars",
                table: "Cars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriver_Cars_CarsId",
                table: "CarDriver",
                column: "CarsId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Cars_Makes_MakeId",
                table: "Cars",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Radios_Cars_CarId",
                table: "Radios",
                column: "CarId",
                principalTable: "Cars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
