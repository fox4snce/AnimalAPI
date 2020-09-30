using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class AddCharacteristicsRemoveOthers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Breeds_BreedId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_CoatTypes_CoatTypeId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Colors_ColorId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_AllSpecies_SpeciesId",
                table: "BreedingRecords");

            migrationBuilder.DropForeignKey(
                name: "FK_BreedingRecords_Varieties_VarietyId",
                table: "BreedingRecords");

            migrationBuilder.DropTable(
                name: "AllSpecies");

            migrationBuilder.DropTable(
                name: "Breeds");

            migrationBuilder.DropTable(
                name: "CharacterSkills");

            migrationBuilder.DropTable(
                name: "CoatTypes");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Varieties");

            migrationBuilder.DropTable(
                name: "Weapons");

            migrationBuilder.DropTable(
                name: "Skills");

            migrationBuilder.DropTable(
                name: "Characters");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_BreedId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_CoatTypeId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_ColorId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_SpeciesId",
                table: "BreedingRecords");

            migrationBuilder.DropIndex(
                name: "IX_BreedingRecords_VarietyId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "BreedId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "CoatTypeId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "SpeciesId",
                table: "BreedingRecords");

            migrationBuilder.DropColumn(
                name: "VarietyId",
                table: "BreedingRecords");

            migrationBuilder.CreateTable(
                name: "Characteristics",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Category = table.Column<string>(nullable: true),
                    Feature = table.Column<string>(nullable: true),
                    BreedingRecordId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characteristics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characteristics_BreedingRecords_BreedingRecordId",
                        column: x => x.BreedingRecordId,
                        principalTable: "BreedingRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Characteristics_BreedingRecordId",
                table: "Characteristics",
                column: "BreedingRecordId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Characteristics");

            migrationBuilder.AddColumn<int>(
                name: "BreedId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CoatTypeId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeciesId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VarietyId",
                table: "BreedingRecords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "AllSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AllSpecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AllSpecies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Breeds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Breeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Breeds_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Characters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Class = table.Column<int>(type: "int", nullable: false),
                    Defeats = table.Column<int>(type: "int", nullable: false),
                    Defense = table.Column<int>(type: "int", nullable: false),
                    Fights = table.Column<int>(type: "int", nullable: false),
                    HitPoints = table.Column<int>(type: "int", nullable: false),
                    Intelligence = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    Strength = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Victories = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Characters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Characters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CoatTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoatTypes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoatTypes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Skills",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Skills", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Varieties",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Varieties", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Varieties_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Weapons",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    Damage = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Weapons", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Weapons_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CharacterSkills",
                columns: table => new
                {
                    CharacterId = table.Column<int>(type: "int", nullable: false),
                    SkillId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CharacterSkills", x => new { x.CharacterId, x.SkillId });
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Characters_CharacterId",
                        column: x => x.CharacterId,
                        principalTable: "Characters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CharacterSkills_Skills_SkillId",
                        column: x => x.SkillId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_BreedId",
                table: "BreedingRecords",
                column: "BreedId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_CoatTypeId",
                table: "BreedingRecords",
                column: "CoatTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_ColorId",
                table: "BreedingRecords",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_SpeciesId",
                table: "BreedingRecords",
                column: "SpeciesId");

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecords_VarietyId",
                table: "BreedingRecords",
                column: "VarietyId");

            migrationBuilder.CreateIndex(
                name: "IX_AllSpecies_UserId",
                table: "AllSpecies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Breeds_UserId",
                table: "Breeds",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Characters_UserId",
                table: "Characters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_CharacterSkills_SkillId",
                table: "CharacterSkills",
                column: "SkillId");

            migrationBuilder.CreateIndex(
                name: "IX_CoatTypes_UserId",
                table: "CoatTypes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Varieties_UserId",
                table: "Varieties",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Weapons_CharacterId",
                table: "Weapons",
                column: "CharacterId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Breeds_BreedId",
                table: "BreedingRecords",
                column: "BreedId",
                principalTable: "Breeds",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_CoatTypes_CoatTypeId",
                table: "BreedingRecords",
                column: "CoatTypeId",
                principalTable: "CoatTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Colors_ColorId",
                table: "BreedingRecords",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_AllSpecies_SpeciesId",
                table: "BreedingRecords",
                column: "SpeciesId",
                principalTable: "AllSpecies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BreedingRecords_Varieties_VarietyId",
                table: "BreedingRecords",
                column: "VarietyId",
                principalTable: "Varieties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
