using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class NoteChanges : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecordNotes_BreedingRecords_BreedingRecordId",
                table: "BreedingRecordNotes");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecordNotes_BreedingRecordId",
                table: "BreedingRecordNotes");

            migrationBuilder.DropColumn(
                name: "Type",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "BreedingRecordId",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactId",
                table: "Notes",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Notes_BreedingRecordId",
                table: "Notes",
                column: "BreedingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_ContactId",
                table: "Notes",
                column: "ContactId");

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_BreedingRecords_BreedingRecordId",
                table: "Notes",
                column: "BreedingRecordId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Contacts_ContactId",
                table: "Notes",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Notes_BreedingRecords_BreedingRecordId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Contacts_ContactId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_BreedingRecordId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_Notes_ContactId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "BreedingRecordId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "ContactId",
                table: "Notes");

            migrationBuilder.AddColumn<int>(
                name: "Type",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecordNotes_BreedingRecordId",
                table: "BreedingRecordNotes",
                column: "BreedingRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecordNotes_BreedingRecords_BreedingRecordId",
                table: "BreedingRecordNotes",
                column: "BreedingRecordId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
