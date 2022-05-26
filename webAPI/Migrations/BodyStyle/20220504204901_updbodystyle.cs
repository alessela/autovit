using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations.BodyStyle
{
    public partial class updbodystyle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "name",
                table: "BodyStyle",
                newName: "Name");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "BodyStyle",
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
                table: "BodyStyle",
                newName: "name");

            migrationBuilder.UpdateData(
                table: "BodyStyle",
                keyColumn: "name",
                keyValue: null,
                column: "name",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "BodyStyle",
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
