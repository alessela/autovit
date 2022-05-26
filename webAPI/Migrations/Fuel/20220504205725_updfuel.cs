using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations.Fuel
{
    public partial class updfuel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "Fuel",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Fuel",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(32)")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Fuel",
                newName: "name");

            migrationBuilder.UpdateData(
                table: "Fuel",
                keyColumn: "name",
                keyValue: null,
                column: "name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Fuel",
                type: "varchar(32)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
