using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AutoLot.Samples.Migrations
{
    /// <inheritdoc />
    public partial class One2ManyFluent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Makes_MakeId",
                schema: "public",
                table: "Inventory");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Makes_MakeId",
                schema: "public",
                table: "Inventory",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Inventory_Makes_MakeId",
                schema: "public",
                table: "Inventory");

            migrationBuilder.AddForeignKey(
                name: "FK_Inventory_Makes_MakeId",
                schema: "public",
                table: "Inventory",
                column: "MakeId",
                principalTable: "Makes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
