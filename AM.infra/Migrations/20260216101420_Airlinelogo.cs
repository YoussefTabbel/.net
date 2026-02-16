using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infra.Migrations
{
    /// <inheritdoc />
    public partial class Airlinelogo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AirlineLogo",
                table: "Flights",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirlineLogo",
                table: "Flights");
        }
    }
}
