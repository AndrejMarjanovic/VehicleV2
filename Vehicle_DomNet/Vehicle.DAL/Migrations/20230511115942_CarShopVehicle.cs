using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.DAL.Migrations
{
    /// <inheritdoc />
    public partial class CarShopVehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_CarShop_CarShopId",
                table: "Contract");

            migrationBuilder.DropForeignKey(
                name: "FK_Contract_Vehicle_VehicleId",
                table: "Contract");

            migrationBuilder.DropIndex(
                name: "IX_Contract_CarShopId",
                table: "Contract");

            migrationBuilder.DropColumn(
                name: "CarShopId",
                table: "Contract");

            migrationBuilder.RenameColumn(
                name: "VehicleId",
                table: "Contract",
                newName: "CarShopVehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_VehicleId",
                table: "Contract",
                newName: "IX_Contract_CarShopVehicleId");

            migrationBuilder.CreateTable(
                name: "CarShopVehicle",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CarShopId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarShopVehicle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarShopVehicle_CarShop_CarShopId",
                        column: x => x.CarShopId,
                        principalTable: "CarShop",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CarShopVehicle_Vehicle_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarShopVehicle_CarShopId",
                table: "CarShopVehicle",
                column: "CarShopId");

            migrationBuilder.CreateIndex(
                name: "IX_CarShopVehicle_VehicleId",
                table: "CarShopVehicle",
                column: "VehicleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_CarShopVehicle_CarShopVehicleId",
                table: "Contract",
                column: "CarShopVehicleId",
                principalTable: "CarShopVehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Contract_CarShopVehicle_CarShopVehicleId",
                table: "Contract");

            migrationBuilder.DropTable(
                name: "CarShopVehicle");

            migrationBuilder.RenameColumn(
                name: "CarShopVehicleId",
                table: "Contract",
                newName: "VehicleId");

            migrationBuilder.RenameIndex(
                name: "IX_Contract_CarShopVehicleId",
                table: "Contract",
                newName: "IX_Contract_VehicleId");

            migrationBuilder.AddColumn<int>(
                name: "CarShopId",
                table: "Contract",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Contract_CarShopId",
                table: "Contract",
                column: "CarShopId");

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_CarShop_CarShopId",
                table: "Contract",
                column: "CarShopId",
                principalTable: "CarShop",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contract_Vehicle_VehicleId",
                table: "Contract",
                column: "VehicleId",
                principalTable: "Vehicle",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
