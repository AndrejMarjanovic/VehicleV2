using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Vehicle.DAL.Migrations
{
    /// <inheritdoc />
    public partial class updatevehicle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Vehicle",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Price",
                table: "Vehicle",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Vehicle");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Vehicle");
        }
    }
}
