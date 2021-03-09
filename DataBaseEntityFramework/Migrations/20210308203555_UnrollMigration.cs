using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    public partial class UnrollMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organization_UserOrganizationId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organization_UserOrganizationId",
                table: "Users",
                column: "UserOrganizationId",
                principalTable: "Organization",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organization_UserOrganizationId",
                table: "Users");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organization_UserOrganizationId",
                table: "Users",
                column: "UserOrganizationId",
                principalTable: "Organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
