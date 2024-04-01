using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace AutoLot.Samples.Migrations
{
    /// <inheritdoc />
    public partial class One2One : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Radios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    HasTweeters = table.Column<bool>(type: "boolean", nullable: false),
                    HasSubWoofers = table.Column<bool>(type: "boolean", nullable: false),
                    RadioId = table.Column<string>(type: "text", nullable: false),
                    CarId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Radios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Radios_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Radios_CarId",
                table: "Radios",
                column: "CarId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Radios");
        }
    }
}
