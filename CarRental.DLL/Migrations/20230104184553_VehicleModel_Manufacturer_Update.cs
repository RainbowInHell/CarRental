using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DLL.Migrations
{
    /// <inheritdoc />
    public partial class VehicleModelManufacturerUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddUniqueConstraint(
                name: "AK_VehicleModels_Name",
                table: "VehicleModels",
                column: "Name");

            migrationBuilder.AddUniqueConstraint(
                name: "AK_Manufacturers_Name",
                table: "Manufacturers",
                column: "Name");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropUniqueConstraint(
                name: "AK_VehicleModels_Name",
                table: "VehicleModels");

            migrationBuilder.DropUniqueConstraint(
                name: "AK_Manufacturers_Name",
                table: "Manufacturers");
        }
    }
}
