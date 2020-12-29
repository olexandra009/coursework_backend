using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    public partial class FixApplication : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "Rights",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Application",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Rights_UserId1",
                table: "Rights",
                column: "UserId1",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Rights_Users_UserId1",
                table: "Rights",
                column: "UserId1",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rights_Users_UserId1",
                table: "Rights");

            migrationBuilder.DropIndex(
                name: "IX_Rights_UserId1",
                table: "Rights");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "Rights");

            migrationBuilder.AlterColumn<int>(
                name: "AnswerId",
                table: "Application",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
