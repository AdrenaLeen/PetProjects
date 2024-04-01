using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLot.Samples.Migrations
{
    /// <inheritdoc />
    public partial class Many2ManyFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDriver_Drivers_DriversId",
                table: "CarDriver");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDriver_Inventory_CarsId",
                table: "CarDriver");

            migrationBuilder.RenameColumn(
                name: "DriversId",
                table: "CarDriver",
                newName: "DriverId");

            migrationBuilder.RenameColumn(
                name: "CarsId",
                table: "CarDriver",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarDriver_DriversId",
                table: "CarDriver",
                newName: "IX_CarDriver_DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriver_Cars_CarId",
                table: "CarDriver",
                column: "CarId",
                principalSchema: "public",
                principalTable: "Inventory",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriver_Drivers_DrvierId",
                table: "CarDriver",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarDriver_Cars_CarId",
                table: "CarDriver");

            migrationBuilder.DropForeignKey(
                name: "FK_CarDriver_Drivers_DrvierId",
                table: "CarDriver");

            migrationBuilder.RenameColumn(
                name: "DriverId",
                table: "CarDriver",
                newName: "DriversId");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "CarDriver",
                newName: "CarsId");

            migrationBuilder.RenameIndex(
                name: "IX_CarDriver_DriverId",
                table: "CarDriver",
                newName: "IX_CarDriver_DriversId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriver_Drivers_DriversId",
                table: "CarDriver",
                column: "DriversId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CarDriver_Inventory_CarsId",
                table: "CarDriver",
                column: "CarsId",
                principalSchema: "public",
                principalTable: "Inventory",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
