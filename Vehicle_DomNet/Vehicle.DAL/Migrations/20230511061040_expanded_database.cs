using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.DAL.Migrations
{
    /// <inheritdoc />
    public partial class expanded_database : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Transmission_TransmissionId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleSeat_VehicleSeatsId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle");

            migrationBuilder.DropTable(
                name: "VehicleSeat");

            migrationBuilder.DropIndex(
                name: "IX_Vehicle_TransmissionId",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "TransmissionId",
                table: "Vehicle");

            migrationBuilder.RenameColumn(
                name: "VehicleTypeId",
                table: "Vehicle",
                newName: "SeatsId");

            migrationBuilder.RenameColumn(
                name: "VehicleSeatsId",
                table: "Vehicle",
                newName: "EngineId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_VehicleTypeId",
                table: "Vehicle",
                newName: "IX_Vehicle_SeatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_VehicleSeatsId",
                table: "Vehicle",
                newName: "IX_Vehicle_EngineId");

            migrationBuilder.AddColumn<int>(
                name: "VehicleTypeId",
                table: "VehicleModel",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "FuelType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmissionStandard = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FuelType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SeatType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Engine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cubage = table.Column<double>(type: "float", nullable: false),
                    Horsepower = table.Column<int>(type: "int", nullable: false),
                    FuelTypeId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    IsHybrid = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Engine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Engine_FuelType_FuelTypeId",
                        column: x => x.FuelTypeId,
                        principalTable: "FuelType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Engine_Transmission_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "SeatTypeColour",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SeatTypeId = table.Column<int>(type: "int", nullable: false),
                    ColourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeatTypeColour", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SeatTypeColour_Colour_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SeatTypeColour_SeatType_SeatTypeId",
                        column: x => x.SeatTypeId,
                        principalTable: "SeatType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    SeatTypeColourId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_SeatTypeColour_SeatTypeColourId",
                        column: x => x.SeatTypeColourId,
                        principalTable: "SeatTypeColour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModel_VehicleTypeId",
                table: "VehicleModel",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_FuelTypeId",
                table: "Engine",
                column: "FuelTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Engine_TransmissionId",
                table: "Engine",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_SeatTypeColourId",
                table: "Seat",
                column: "SeatTypeColourId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatTypeColour_ColourId",
                table: "SeatTypeColour",
                column: "ColourId");

            migrationBuilder.CreateIndex(
                name: "IX_SeatTypeColour_SeatTypeId",
                table: "SeatTypeColour",
                column: "SeatTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Engine_EngineId",
                table: "Vehicle",
                column: "EngineId",
                principalTable: "Engine",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Seat_SeatsId",
                table: "Vehicle",
                column: "SeatsId",
                principalTable: "Seat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModel_VehicleType_VehicleTypeId",
                table: "VehicleModel",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Engine_EngineId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicle_Seat_SeatsId",
                table: "Vehicle");

            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModel_VehicleType_VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.DropTable(
                name: "Engine");

            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "FuelType");

            migrationBuilder.DropTable(
                name: "SeatTypeColour");

            migrationBuilder.DropTable(
                name: "SeatType");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModel_VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "VehicleModel");

            migrationBuilder.RenameColumn(
                name: "SeatsId",
                table: "Vehicle",
                newName: "VehicleTypeId");

            migrationBuilder.RenameColumn(
                name: "EngineId",
                table: "Vehicle",
                newName: "VehicleSeatsId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_SeatsId",
                table: "Vehicle",
                newName: "IX_Vehicle_VehicleTypeId");

            migrationBuilder.RenameIndex(
                name: "IX_Vehicle_EngineId",
                table: "Vehicle",
                newName: "IX_Vehicle_VehicleSeatsId");

            migrationBuilder.AddColumn<int>(
                name: "TransmissionId",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "VehicleSeat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColourId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleSeat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VehicleSeat_Colour_ColourId",
                        column: x => x.ColourId,
                        principalTable: "Colour",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicle_TransmissionId",
                table: "Vehicle",
                column: "TransmissionId");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleSeat_ColourId",
                table: "VehicleSeat",
                column: "ColourId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_Transmission_TransmissionId",
                table: "Vehicle",
                column: "TransmissionId",
                principalTable: "Transmission",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleSeat_VehicleSeatsId",
                table: "Vehicle",
                column: "VehicleSeatsId",
                principalTable: "VehicleSeat",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicle_VehicleType_VehicleTypeId",
                table: "Vehicle",
                column: "VehicleTypeId",
                principalTable: "VehicleType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
