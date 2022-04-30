using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webAPI.Migrations.User
{
    public partial class user2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<sbyte>(
                name: "is_admin",
                table: "User",
                type: "tinyint",
                nullable: false,
                oldClrType: typeof(ulong),
                oldType: "bit");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<ulong>(
                name: "is_admin",
                table: "User",
                type: "bit",
                nullable: false,
                oldClrType: typeof(sbyte),
                oldType: "tinyint");
        }
    }
}
