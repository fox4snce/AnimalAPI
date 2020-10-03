using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class AddCharacteristicsUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Characteristics",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_UserId",
                table: "Characteristics",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_Users_UserId",
                table: "Characteristics",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_Users_UserId",
                table: "Characteristics");

            migrationBuilder.DropIndex(
                name: "IX_Characteristics_UserId",
                table: "Characteristics");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Characteristics");
        }
    }
}
