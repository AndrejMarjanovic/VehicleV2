using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.DAL.Migrations
{
    /// <inheritdoc />
    public partial class third : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmissionStandard",
                table: "FuelType");

            migrationBuilder.AddColumn<int>(
                name: "CountryId",
                table: "VehicleMake",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mileage",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ProductionYear",
                table: "Vehicle",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "EmissionStandard",
                table: "Engine",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContryName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintainanceHistory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaintainanceInfo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VehicleEntityId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintainanceHistory", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintainanceHistory_Vehicle_VehicleEntityId",
                        column: x => x.VehicleEntityId,
                        principalTable: "Vehicle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VehicleMake_CountryId",
                table: "VehicleMake",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintainanceHistory_VehicleEntityId",
                table: "MaintainanceHistory",
                column: "VehicleEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleMake_Country_CountryId",
                table: "VehicleMake",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleMake_Country_CountryId",
                table: "VehicleMake");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropTable(
                name: "MaintainanceHistory");

            migrationBuilder.DropIndex(
                name: "IX_VehicleMake_CountryId",
                table: "VehicleMake");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "VehicleMake");

            migrationBuilder.DropColumn(
                name: "Mileage",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "ProductionYear",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "EmissionStandard",
                table: "Engine");

            migrationBuilder.AddColumn<string>(
                name: "EmissionStandard",
                table: "FuelType",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
