using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class BackToSplitNotes2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecordNotes_BreedingRecords_BreedingRecordId",
                table: "BreedingRecordNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactNotes_Contacts_ContactId",
                table: "ContactNotes");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "ContactNotes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BreedingRecordId",
                table: "BreedingRecordNotes",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecordNotes_BreedingRecords_BreedingRecordId",
                table: "BreedingRecordNotes",
                column: "BreedingRecordId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactNotes_Contacts_ContactId",
                table: "ContactNotes",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecordNotes_BreedingRecords_BreedingRecordId",
                table: "BreedingRecordNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_ContactNotes_Contacts_ContactId",
                table: "ContactNotes");

            migrationBuilder.AlterColumn<int>(
                name: "ContactId",
                table: "ContactNotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BreedingRecordId",
                table: "BreedingRecordNotes",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecordNotes_BreedingRecords_BreedingRecordId",
                table: "BreedingRecordNotes",
                column: "BreedingRecordId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ContactNotes_Contacts_ContactId",
                table: "ContactNotes",
                column: "ContactId",
                principalTable: "Contacts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
