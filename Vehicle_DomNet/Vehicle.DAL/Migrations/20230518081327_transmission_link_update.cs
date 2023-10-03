using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.DAL.Migrations
{
    /// <inheritdoc />
    public partial class transmission_link_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Engine_Transmission_TransmissionId",
                table: "Engine");

            migrationBuilder.DropIndex(
                name: "IX_Engine_TransmissionId",
                table: "Engine");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Engine");

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TransmissionId",
                table: "Vehicle",
                column: "TransmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Transmission_TransmissionId",
                table: "Vehicle",
                column: "TransmissionId",
                principalTable: "Transmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Transmission_TransmissionId",
                table: "Vehicle");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_TransmissionId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Vehicle");

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Engine",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Engine_TransmissionId",
                table: "Engine",
                column: "TransmissionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Engine_Transmission_TransmissionId",
                table: "Engine",
                column: "TransmissionId",
                principalTable: "Transmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
