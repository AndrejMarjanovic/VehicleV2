using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatevehicleentity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintainanceHistory_Vehicle_VehicleEntityId",
                table: "MaintainanceHistory");

            migrationBuilder.RenameColumn(
                name: "VehicleEntityId",
                table: "MaintainanceHistory",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintainanceHistory_VehicleEntityId",
                table: "MaintainanceHistory",
                newName: "IX_MaintainanceHistory_VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintainanceHistory_Vehicle_VehicleId",
                table: "MaintainanceHistory",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MaintainanceHistory_Vehicle_VehicleId",
                table: "MaintainanceHistory");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "MaintainanceHistory",
                newName: "VehicleEntityId");

            migrationBuilder.RenameIndex(
                name: "IX_MaintainanceHistory_VehicleId",
                table: "MaintainanceHistory",
                newName: "IX_MaintainanceHistory_VehicleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_MaintainanceHistory_Vehicle_VehicleEntityId",
                table: "MaintainanceHistory",
                column: "VehicleEntityId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
