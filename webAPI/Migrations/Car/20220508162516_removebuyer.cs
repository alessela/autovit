using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations.Car
{
    public partial class removebuyer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BuyerId",
                table: "Car",
                type: "int",
                nullable: false,
                defaultValue: 0);

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
    }
}
