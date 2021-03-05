using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    public partial class AddAnswerToPetition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Answer",
                table: "Petition",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Answer",
                table: "Petition");
        }
    }
}
