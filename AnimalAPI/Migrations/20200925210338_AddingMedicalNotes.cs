using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class AddingMedicalNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BreedingRecordId",
                table: "MedicalNotes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MedicalNotes_BreedingRecordId",
                table: "MedicalNotes",
                column: "BreedingRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalNotes_BreedingRecords_BreedingRecordId",
                table: "MedicalNotes",
                column: "BreedingRecordId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MedicalNotes_BreedingRecords_BreedingRecordId",
                table: "MedicalNotes");

            migrationBuilder.DropIndex(
                name: "IX_MedicalNotes_BreedingRecordId",
                table: "MedicalNotes");

            migrationBuilder.DropColumn(
                name: "BreedingRecordId",
                table: "MedicalNotes");
        }
    }
}
