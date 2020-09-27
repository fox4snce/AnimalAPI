using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class FixThePoorParentsAndLitters : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_BreedingRecords_FatherId",
                table: "Litters");

            migrationBuilder.DropForeignKey(
                name: "FK_Litters_BreedingRecords_MotherId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_BreedingRecordId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_FatherId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_Litters_MotherId",
                table: "Litters");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_BelongsToLitterId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_FatherId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_MotherId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "BreedingRecordId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "Litters");

            migrationBuilder.DropColumn(
                name: "BelongsToLitterId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "FatherId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "MotherId",
                table: "BreedingRecords");

            migrationBuilder.AddColumn<int>(
                name: "LitterId",
                table: "BreedingRecords",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ParentRecords",
                columns: table => new
                {
                    ParentId = table.Column<int>(nullable: false),
                    LitterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ParentRecords", x => new { x.ParentId, x.LitterId });
                    table.ForeignKey(
                        name: "FK_ParentRecords_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ParentRecords_BreedingRecords_ParentId",
                        column: x => x.ParentId,
                        principalTable: "BreedingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SiblingRecords",
                columns: table => new
                {
                    SiblingId = table.Column<int>(nullable: false),
                    LitterId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiblingRecords", x => new { x.SiblingId, x.LitterId });
                    table.ForeignKey(
                        name: "FK_SiblingRecords_Litters_LitterId",
                        column: x => x.LitterId,
                        principalTable: "Litters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SiblingRecords_BreedingRecords_SiblingId",
                        column: x => x.SiblingId,
                        principalTable: "BreedingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_LitterId",
                table: "BreedingRecords",
                column: "LitterId");

            migrationBuilder.CreateIndex(
                name: "IX_ParentRecords_LitterId",
                table: "ParentRecords",
                column: "LitterId");

            migrationBuilder.CreateIndex(
                name: "IX_SiblingRecords_LitterId",
                table: "SiblingRecords",
                column: "LitterId");

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Litters_LitterId",
                table: "BreedingRecords",
                column: "LitterId",
                principalTable: "Litters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Litters_LitterId",
                table: "BreedingRecords");

            migrationBuilder.DropTable(
                name: "ParentRecords");

            migrationBuilder.DropTable(
                name: "SiblingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_LitterId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "LitterId",
                table: "BreedingRecords");

            migrationBuilder.AddColumn<int>(
                name: "BreedingRecordId",
                table: "Litters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "Litters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "Litters",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BelongsToLitterId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FatherId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Litters_BreedingRecordId",
                table: "Litters",
                column: "BreedingRecordId");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_FatherId",
                table: "Litters",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_Litters_MotherId",
                table: "Litters",
                column: "MotherId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_BelongsToLitterId",
                table: "BreedingRecords",
                column: "BelongsToLitterId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_FatherId",
                table: "BreedingRecords",
                column: "FatherId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_MotherId",
                table: "BreedingRecords",
                column: "MotherId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_BreedingRecords_FatherId",
                table: "Litters",
                column: "FatherId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Litters_BreedingRecords_MotherId",
                table: "Litters",
                column: "MotherId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
