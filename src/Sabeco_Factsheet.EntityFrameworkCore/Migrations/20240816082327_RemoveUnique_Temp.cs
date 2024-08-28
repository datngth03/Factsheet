using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sabeco_Factsheet.Migrations
{
    /// <inheritdoc />
    public partial class RemoveUnique_Temp : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_tbBrewerySKU_Temp_BreweryId_SKUId_Year",
                table: "tbBrewerySKU_Temp");

            migrationBuilder.DropIndex(
                name: "IX_tbBreweryDeliveryVolume_Temp_BreweryId_Year",
                table: "tbBreweryDeliveryVolume_Temp");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_tbBrewerySKU_Temp_BreweryId_SKUId_Year",
                table: "tbBrewerySKU_Temp",
                columns: new[] { "BreweryId", "SKUId", "Year" },
                unique: true,
                filter: "[BreweryId] IS NOT NULL AND [SKUId] IS NOT NULL AND [Year] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbBreweryDeliveryVolume_Temp_BreweryId_Year",
                table: "tbBreweryDeliveryVolume_Temp",
                columns: new[] { "BreweryId", "Year" },
                unique: true,
                filter: "[BreweryId] IS NOT NULL AND [Year] IS NOT NULL");
        }
    }
}
