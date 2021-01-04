using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    public partial class AddAuthentification : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rights");

            migrationBuilder.AddColumn<bool>(
                name: "EmailConfirm",
                table: "Users",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "Role",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailConfirm",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Role",
                table: "Users");

            migrationBuilder.CreateTable(
                name: "Rights",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    AddingUser = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateApplication = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreateNewsAndEvents = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CreatePetitions = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    EditRights = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    HandlingApplication = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    ModerateNewsAndEvents = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserId1 = table.Column<int>(type: "int", nullable: true),
                    VotePetitions = table.Column<bool>(type: "tinyint(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rights", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rights_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Rights_Users_UserId1",
                        column: x => x.UserId1,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rights_UserId",
                table: "Rights",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rights_UserId1",
                table: "Rights",
                column: "UserId1",
                unique: true);
        }
    }
}
