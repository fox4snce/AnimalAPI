using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class BreedingRecordGetRidLitterId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Litters_BirthLitterId",
                table: "BreedingRecords");

            migrationBuilder.AlterColumn<int>(
                name: "BirthLitterId",
                table: "BreedingRecords",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AlterColumn<int>(
                name: "BirthLitterId",
                table: "BreedingRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Litters_BirthLitterId",
                table: "BreedingRecords",
                column: "BirthLitterId",
                principalTable: "Litters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
