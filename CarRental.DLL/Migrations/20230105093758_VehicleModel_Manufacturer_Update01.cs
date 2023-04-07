using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DLL.Migrations
{
    /// <inheritdoc />
    public partial class VehicleModelManufacturerUpdate01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_VehicleModels_Name",
                table: "VehicleModels");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Manufacturers_Name",
                table: "Manufacturers");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_Name",
                table: "VehicleModels",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_Name",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_Manufacturers_Name",
                table: "Manufacturers");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_VehicleModels_Name",
                table: "VehicleModels",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name");
        }
    }
}
