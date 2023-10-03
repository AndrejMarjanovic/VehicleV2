using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.DAL.Migrations
{
    /// <inheritdoc />
    public partial class vTypeLinkUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModel_VehicleType_VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModel_VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "VehicleModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleTypeId",
                table: "VehicleModel",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModel_VehicleType_VehicleTypeId",
                table: "VehicleModel",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
