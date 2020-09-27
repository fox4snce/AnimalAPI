using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class RemovedMotherFatherId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherId1",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherIdId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherId1",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherIdId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_FatherId1",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_FatherIdId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_MotherId1",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_MotherIdId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "FatherId1",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "FatherIdId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "MotherId1",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "MotherIdId",
                table: "BreedingRecords");

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "BreedingRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "BreedingRecords",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_FatherId",
                table: "BreedingRecords",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_MotherId",
                table: "BreedingRecords",
                column: "MotherId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherId",
                table: "BreedingRecords",
                column: "FatherId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherId",
                table: "BreedingRecords",
                column: "MotherId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_FatherId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_MotherId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "BreedingRecords");

            migrationBuilder.AddColumn<int>(
                name: "FatherId1",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FatherIdId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId1",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherIdId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_FatherId1",
                table: "BreedingRecords",
                column: "FatherId1");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_FatherIdId",
                table: "BreedingRecords",
                column: "FatherIdId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_MotherId1",
                table: "BreedingRecords",
                column: "MotherId1");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_MotherIdId",
                table: "BreedingRecords",
                column: "MotherIdId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherId1",
                table: "BreedingRecords",
                column: "FatherId1",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherIdId",
                table: "BreedingRecords",
                column: "FatherIdId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherId1",
                table: "BreedingRecords",
                column: "MotherId1",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherIdId",
                table: "BreedingRecords",
                column: "MotherIdId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
