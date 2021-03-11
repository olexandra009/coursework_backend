using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    public partial class ChangeToCascade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Multimedia_News_NewsId",
                table: "Multimedia");

            migrationBuilder.AddForeignKey(
                name: "FK_Multimedia_News_NewsId",
                table: "Multimedia",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Multimedia_News_NewsId",
                table: "Multimedia");

            migrationBuilder.AddForeignKey(
                name: "FK_Multimedia_News_NewsId",
                table: "Multimedia",
                column: "NewsId",
                principalTable: "News",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
