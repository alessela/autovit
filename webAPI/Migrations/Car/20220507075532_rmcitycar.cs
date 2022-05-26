using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations.Car
{
    public partial class rmcitycar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Car",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ModelId = table.Column<int>(type: "int", nullable: false),
                    BodyStyleId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Mileage = table.Column<int>(type: "int", nullable: false),
                    FuelId = table.Column<int>(type: "int", nullable: false),
                    TransmissionId = table.Column<int>(type: "int", nullable: false),
                    Engine = table.Column<int>(type: "int", nullable: false),
                    Power = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false),
                    Lhd = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Used = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    SellerId = table.Column<int>(type: "int", nullable: false),
                    Sold = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Car", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Car_BodyStyle_BodyStyleId",
                        column: x => x.BodyStyleId,
                        principalTable: "BodyStyle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Car_Color_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Color",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Car_Fuel_FuelId",
                        column: x => x.FuelId,
                        principalTable: "Fuel",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Car_Model_ModelId",
                        column: x => x.ModelId,
                        principalTable: "Model",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Car_Transmission_TransmissionId",
                        column: x => x.TransmissionId,
                        principalTable: "Transmission",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Car_User_SellerId",
                        column: x => x.SellerId,
                        principalTable: "User",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Car_BodyStyleId",
                table: "Car",
                column: "BodyStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ColorId",
                table: "Car",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_FuelId",
                table: "Car",
                column: "FuelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_ModelId",
                table: "Car",
                column: "ModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_SellerId",
                table: "Car",
                column: "SellerId");

            migrationBuilder.CreateIndex(
                name: "IX_Car_TransmissionId",
                table: "Car",
                column: "TransmissionId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Car");

            migrationBuilder.DropTable(
                name: "BodyStyle");

            migrationBuilder.DropTable(
                name: "Color");

            migrationBuilder.DropTable(
                name: "Fuel");

            migrationBuilder.DropTable(
                name: "Model");

            migrationBuilder.DropTable(
                name: "Transmission");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
