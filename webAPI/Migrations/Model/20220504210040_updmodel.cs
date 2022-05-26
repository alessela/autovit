using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations.Model
{
    public partial class updmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Brand_brand_id",
                table: "Model");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "Model",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "brand_id",
                table: "Model",
                newName: "BrandId");

            migrationBuilder.RenameColumn(
                name: "int",
                table: "Model",
                newName: "Id");

            migrationBuilder.RenameIndex(
                name: "IX_Model_brand_id",
                table: "Model",
                newName: "IX_Model_BrandId");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Model",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(32)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Brand_BrandId",
                table: "Model",
                column: "BrandId",
                principalTable: "Brand",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Model_Brand_BrandId",
                table: "Model");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Model",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "BrandId",
                table: "Model",
                newName: "brand_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Model",
                newName: "int");

            migrationBuilder.RenameIndex(
                name: "IX_Model_BrandId",
                table: "Model",
                newName: "IX_Model_brand_id");

            migrationBuilder.UpdateData(
                table: "Model",
                keyColumn: "name",
                keyValue: null,
                column: "name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Model",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_Model_Brand_brand_id",
                table: "Model",
                column: "brand_id",
                principalTable: "Brand",
                principalColumn: "Id");
        }
    }
}
