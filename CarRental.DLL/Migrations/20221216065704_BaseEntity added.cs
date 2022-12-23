using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.DLL.Migrations
{
    /// <inheritdoc />
    public partial class BaseEntityadded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Bookings_VehicleID",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "VehicleID",
                table: "Vehicles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "VehicleModelID",
                table: "VehicleModels",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "ManufacturerID",
                table: "Manufacturers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "Customers",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "BookingID",
                table: "Bookings",
                newName: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Bookings_Id",
                table: "Vehicles",
                column: "Id",
                principalTable: "Bookings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Bookings_Id",
                table: "Vehicles");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Vehicles",
                newName: "VehicleID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "VehicleModels",
                newName: "VehicleModelID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Manufacturers",
                newName: "ManufacturerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Customers",
                newName: "CustomerID");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Bookings",
                newName: "BookingID");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Bookings_VehicleID",
                table: "Vehicles",
                column: "VehicleID",
                principalTable: "Bookings",
                principalColumn: "BookingID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}