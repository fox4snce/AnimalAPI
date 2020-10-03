using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class BreedingRecordCharacteristic : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Characteristics_BreedingRecords_BreedingRecordId",
                table: "Characteristics");

            migrationBuilder.DropIndex(
                name: "IX_Characteristics_BreedingRecordId",
                table: "Characteristics");

            migrationBuilder.DropColumn(
                name: "BreedingRecordId",
                table: "Characteristics");

            migrationBuilder.CreateTable(
                name: "BreedingRecordCharacteristics",
                columns: table => new
                {
                    BreedingRecordId = table.Column<int>(nullable: false),
                    CharacteristicId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedingRecordCharacteristics", x => new { x.BreedingRecordId, x.CharacteristicId });
                    table.ForeignKey(
                        name: "FK_BreedingRecordCharacteristics_BreedingRecords_BreedingRecord~",
                        column: x => x.BreedingRecordId,
                        principalTable: "BreedingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BreedingRecordCharacteristics_Characteristics_Characteristic~",
                        column: x => x.CharacteristicId,
                        principalTable: "Characteristics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecordCharacteristics_CharacteristicId",
                table: "BreedingRecordCharacteristics",
                column: "CharacteristicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedingRecordCharacteristics");

            migrationBuilder.AddColumn<int>(
                name: "BreedingRecordId",
                table: "Characteristics",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_BreedingRecordId",
                table: "Characteristics",
                column: "BreedingRecordId");

            migrationBuilder.AddForeignKey(
                name: "FK_Characteristics_BreedingRecords_BreedingRecordId",
                table: "Characteristics",
                column: "BreedingRecordId",
                principalTable: "BreedingRecords",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
