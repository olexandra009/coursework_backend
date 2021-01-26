using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    public partial class FixEmailConfirmRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_EmailConfirm_Users_UserId",
                table: "EmailConfirm",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmailConfirm_Users_UserId",
                table: "EmailConfirm");
        }
    }
}
