using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class BirthLitterAddedToDtos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Litters_LitterId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_LitterId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "LitterId",
                table: "BreedingRecords");

            migrationBuilder.AddColumn<int>(
                name: "BirthLitterId",
                table: "BreedingRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_BirthLitterId",
                table: "BreedingRecords",
                column: "BirthLitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Litters_BirthLitterId",
                table: "BreedingRecords",
                column: "BirthLitterId",
                principalTable: "Litters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Litters_BirthLitterId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_BirthLitterId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "BirthLitterId",
                table: "BreedingRecords");

            migrationBuilder.AddColumn<int>(
                name: "LitterId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_LitterId",
                table: "BreedingRecords",
                column: "LitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Litters_LitterId",
                table: "BreedingRecords",
                column: "LitterId",
                principalTable: "Litters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
