using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class AddingConnectionsParentsAndLitters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherId",
                table: "BreedingRecords");

            migrationBuilder.DropTable(
                name: "BreedingRecordLitters");

            migrationBuilder.AddColumn<int>(
                name: "BreedingRecordId",
                table: "Litters",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MotherId",
                table: "BreedingRecords",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "FatherId",
                table: "BreedingRecords",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BelongsToLitterId",
                table: "BreedingRecords",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Sex",
                table: "BreedingRecords",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Litters_BreedingRecordId",
                table: "Litters",
                column: "BreedingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_BelongsToLitterId",
                table: "BreedingRecords",
                column: "BelongsToLitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Litters_BelongsToLitterId",
                table: "BreedingRecords",
                column: "BelongsToLitterId",
                principalTable: "Litters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_BreedingRecords_BreedingRecordId",
                table: "Litters",
                column: "BreedingRecordId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Litters_BelongsToLitterId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_BreedingRecords_BreedingRecordId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_BreedingRecordId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_BelongsToLitterId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "BreedingRecordId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "BelongsToLitterId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "Sex",
                table: "BreedingRecords");

            migrationBuilder.AlterColumn<int>(
                name: "MotherId",
                table: "BreedingRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "FatherId",
                table: "BreedingRecords",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "BreedingRecordLitters",
                columns: table => new
                {
                    BreedingRecordId = table.Column<int>(type: "int", nullable: false),
                    LitterId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedingRecordLitters", x => new { x.BreedingRecordId, x.LitterId });
                    table.ForeignKey(
                        name: "FK_BreedingRecordLitters_BreedingRecords_BreedingRecordId",
                        column: x => x.BreedingRecordId,
                        principalTable: "BreedingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedingRecordLitters_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecordLitters_BreedingRecordId",
                table: "BreedingRecordLitters",
                column: "BreedingRecordId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecordLitters_LitterId",
                table: "BreedingRecordLitters",
                column: "LitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_FatherId",
                table: "BreedingRecords",
                column: "FatherId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_BreedingRecords_MotherId",
                table: "BreedingRecords",
                column: "MotherId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
