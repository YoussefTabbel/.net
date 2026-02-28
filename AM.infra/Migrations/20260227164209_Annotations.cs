using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AM.infra.Migrations
{
    /// <inheritdoc />
    public partial class Annotations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "PlaneId",
                table: "Flights",
                newName: "PlaneFk");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneId",
                table: "Flights",
                newName: "IX_Flights_PlaneFk");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneFk",
                table: "Flights",
                column: "PlaneFk",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Flights_Planes_PlaneFk",
                table: "Flights");

            migrationBuilder.RenameColumn(
                name: "PlaneFk",
                table: "Flights",
                newName: "PlaneId");

            migrationBuilder.RenameIndex(
                name: "IX_Flights_PlaneFk",
                table: "Flights",
                newName: "IX_Flights_PlaneId");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Passengers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

            migrationBuilder.AddForeignKey(
                name: "FK_Flights_Planes_PlaneId",
                table: "Flights",
                column: "PlaneId",
                principalTable: "Planes",
                principalColumn: "PlaneId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
