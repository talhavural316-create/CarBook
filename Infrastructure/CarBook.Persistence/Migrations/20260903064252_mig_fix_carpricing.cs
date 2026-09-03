using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarBook.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_fix_carpricing : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_CarPricings_CarPricingId1",
                table: "CarPricings");

            migrationBuilder.DropIndex(
                name: "IX_CarPricings_CarPricingId1",
                table: "CarPricings");

            migrationBuilder.DropColumn(
                name: "CarPricingId1",
                table: "CarPricings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CarPricingId1",
                table: "CarPricings",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CarPricings_CarPricingId1",
                table: "CarPricings",
                column: "CarPricingId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_CarPricings_CarPricingId1",
                table: "CarPricings",
                column: "CarPricingId1",
                principalTable: "CarPricings",
                principalColumn: "CarPricingId");
        }
    }
}
