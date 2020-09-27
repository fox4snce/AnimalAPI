using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class UserToAllAnimalModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Varieties",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Notes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "MedicalNotes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Litters",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Contacts",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "CoatTypes",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Breeds",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "BreedingRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "AllSpecies",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Varieties_UserId",
                table: "Varieties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_UserId",
                table: "Notes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicalNotes_UserId",
                table: "MedicalNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_UserId",
                table: "Litters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CoatTypes_UserId",
                table: "CoatTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_UserId",
                table: "Breeds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_UserId",
                table: "BreedingRecords",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AllSpecies_UserId",
                table: "AllSpecies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_AllSpecies_Users_UserId",
                table: "AllSpecies",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Users_UserId",
                table: "BreedingRecords",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Breeds_Users_UserId",
                table: "Breeds",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CoatTypes_Users_UserId",
                table: "CoatTypes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_Users_UserId",
                table: "Litters",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_MedicalNotes_Users_UserId",
                table: "MedicalNotes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Varieties_Users_UserId",
                table: "Varieties",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AllSpecies_Users_UserId",
                table: "AllSpecies");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Users_UserId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Breeds_Users_UserId",
                table: "Breeds");

            migrationBuilder.DropForeignKey(
                name: "FK_CoatTypes_Users_UserId",
                table: "CoatTypes");

            migrationBuilder.DropForeignKey(
                name: "FK_Contacts_Users_UserId",
                table: "Contacts");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_Users_UserId",
                table: "Litters");

            migrationBuilder.DropForeignKey(
                name: "FK_MedicalNotes_Users_UserId",
                table: "MedicalNotes");

            migrationBuilder.DropForeignKey(
                name: "FK_Notes_Users_UserId",
                table: "Notes");

            migrationBuilder.DropForeignKey(
                name: "FK_Varieties_Users_UserId",
                table: "Varieties");

            migrationBuilder.DropIndex(
                name: "IX_Varieties_UserId",
                table: "Varieties");

            migrationBuilder.DropIndex(
                name: "IX_Notes_UserId",
                table: "Notes");

            migrationBuilder.DropIndex(
                name: "IX_MedicalNotes_UserId",
                table: "MedicalNotes");

            migrationBuilder.DropIndex(
                name: "IX_Litters_UserId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Contacts_UserId",
                table: "Contacts");

            migrationBuilder.DropIndex(
                name: "IX_CoatTypes_UserId",
                table: "CoatTypes");

            migrationBuilder.DropIndex(
                name: "IX_Breeds_UserId",
                table: "Breeds");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_UserId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_AllSpecies_UserId",
                table: "AllSpecies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Varieties");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Notes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "MedicalNotes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Contacts");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "CoatTypes");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Breeds");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "AllSpecies");
        }
    }
}
