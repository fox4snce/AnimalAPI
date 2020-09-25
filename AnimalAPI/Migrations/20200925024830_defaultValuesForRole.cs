using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class defaultValuesForRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                nullable: false,
                defaultValueSql: "Player",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldDefaultValue: "Player");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Role",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "Player",
                oldClrType: typeof(string),
                oldDefaultValueSql: "Player");
        }
    }
}
