using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations.Car
{
    public partial class updcar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Car",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Car_BuyerId",
                table: "Car",
                column: "BuyerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Car_User_BuyerId",
                table: "Car",
                column: "BuyerId",
                principalTable: "User",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Car_User_BuyerId",
                table: "Car");

            migrationBuilder.DropIndex(
                name: "IX_Car_BuyerId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "BuyerId",
                table: "Car");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Car");
        }
    }
}
