using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations.CarEvent
{
    public partial class changeev : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarEvent_Car_carId",
                table: "CarEvent");

            migrationBuilder.DropColumn(
                name: "Event",
                table: "CarEvent");

            migrationBuilder.RenameColumn(
                name: "carId",
                table: "CarEvent",
                newName: "CarId");

            migrationBuilder.RenameIndex(
                name: "IX_CarEvent_carId",
                table: "CarEvent",
                newName: "IX_CarEvent_CarId");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "CarEvent",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_CarEvent_Car_CarId",
                table: "CarEvent",
                column: "CarId",
                principalTable: "Car",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarEvent_Car_CarId",
                table: "CarEvent");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "CarEvent");

            migrationBuilder.RenameColumn(
                name: "CarId",
                table: "CarEvent",
                newName: "carId");

            migrationBuilder.RenameIndex(
                name: "IX_CarEvent_CarId",
                table: "CarEvent",
                newName: "IX_CarEvent_carId");

            migrationBuilder.AddColumn<string>(
                name: "Event",
                table: "CarEvent",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_CarEvent_Car_carId",
                table: "CarEvent",
                column: "carId",
                principalTable: "Car",
                principalColumn: "Id");
        }
    }
}
