using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AnimalAPI.Migrations
{
    public partial class RemovedOldNotes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BreedingRecordNotes");

            migrationBuilder.DropTable(
                name: "ContactNotes");

            migrationBuilder.DropColumn(
                name: "ConnectedId",
                table: "Notes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ConnectedId",
                table: "Notes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BreedingRecordNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    BreedingRecordId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Edited = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Medical = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BreedingRecordNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BreedingRecordNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContactNotes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Body = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    ContactId = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Edited = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Medical = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    Title = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContactNotes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContactNotes_Contacts_ContactId",
                        column: x => x.ContactId,
                        principalTable: "Contacts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ContactNotes_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BreedingRecordNotes_UserId",
                table: "BreedingRecordNotes",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactNotes_ContactId",
                table: "ContactNotes",
                column: "ContactId");

            migrationBuilder.CreateIndex(
                name: "IX_ContactNotes_UserId",
                table: "ContactNotes",
                column: "UserId");
        }
    }
}
