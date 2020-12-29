using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    public partial class Fix_naming_and_fields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_AnswerId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Applications_Users_AuthorId",
                table: "Applications");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Users_AuthorId",
                table: "Events");

            migrationBuilder.DropForeignKey(
                name: "FK_Newses_Users_AuthorId",
                table: "Newses");

            migrationBuilder.DropForeignKey(
                name: "FK_Petitions_Users_AuthorId",
                table: "Petitions");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organizations_UserOrganizationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Petitions_PetitionId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Petitions",
                table: "Petitions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Newses",
                table: "Newses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Events",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Applications",
                table: "Applications");

            migrationBuilder.RenameTable(
                name: "Petitions",
                newName: "Petition");

            migrationBuilder.RenameTable(
                name: "Organizations",
                newName: "Organization");

            migrationBuilder.RenameTable(
                name: "Newses",
                newName: "News");

            migrationBuilder.RenameTable(
                name: "Events",
                newName: "Event");

            migrationBuilder.RenameTable(
                name: "Applications",
                newName: "Application");

            migrationBuilder.RenameColumn(
                name: "StarDate",
                table: "Petition",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "FinishDate",
                table: "Petition",
                newName: "End");

            migrationBuilder.RenameIndex(
                name: "IX_Petitions_AuthorId",
                table: "Petition",
                newName: "IX_Petition_AuthorId");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Organization",
                newName: "Organization name");

            migrationBuilder.RenameColumn(
                name: "DateTimeCreation",
                table: "News",
                newName: "Created");

            migrationBuilder.RenameIndex(
                name: "IX_Newses_AuthorId",
                table: "News",
                newName: "IX_News_AuthorId");

            migrationBuilder.RenameColumn(
                name: "StartDate",
                table: "Event",
                newName: "Start");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Event",
                newName: "EventName");

            migrationBuilder.RenameColumn(
                name: "EndDate",
                table: "Event",
                newName: "End");

            migrationBuilder.RenameIndex(
                name: "IX_Events_AuthorId",
                table: "Event",
                newName: "IX_Event_AuthorId");

            migrationBuilder.RenameColumn(
                name: "OpenDate",
                table: "Application",
                newName: "Open");

            migrationBuilder.RenameColumn(
                name: "CloseDate",
                table: "Application",
                newName: "Close");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_AuthorId",
                table: "Application",
                newName: "IX_Application_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Applications_AnswerId",
                table: "Application",
                newName: "IX_Application_AnswerId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserOrganizationId",
                table: "Users",
                type: "char(36)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "char(36)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Petition",
                table: "Petition",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organization",
                table: "Organization",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_News",
                table: "News",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Event",
                table: "Event",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Application",
                table: "Application",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Users_AnswerId",
                table: "Application",
                column: "AnswerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Application_Users_AuthorId",
                table: "Application",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Event_Users_AuthorId",
                table: "Event",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_News_Users_AuthorId",
                table: "News",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petition_Users_AuthorId",
                table: "Petition",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organization_UserOrganizationId",
                table: "Users",
                column: "UserOrganizationId",
                principalTable: "Organization",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Petition_PetitionId",
                table: "Votes",
                column: "PetitionId",
                principalTable: "Petition",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Application_Users_AnswerId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Application_Users_AuthorId",
                table: "Application");

            migrationBuilder.DropForeignKey(
                name: "FK_Event_Users_AuthorId",
                table: "Event");

            migrationBuilder.DropForeignKey(
                name: "FK_News_Users_AuthorId",
                table: "News");

            migrationBuilder.DropForeignKey(
                name: "FK_Petition_Users_AuthorId",
                table: "Petition");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Organization_UserOrganizationId",
                table: "Users");

            migrationBuilder.DropForeignKey(
                name: "FK_Votes_Petition_PetitionId",
                table: "Votes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Petition",
                table: "Petition");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Organization",
                table: "Organization");

            migrationBuilder.DropPrimaryKey(
                name: "PK_News",
                table: "News");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Event",
                table: "Event");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Application",
                table: "Application");

            migrationBuilder.RenameTable(
                name: "Petition",
                newName: "Petitions");

            migrationBuilder.RenameTable(
                name: "Organization",
                newName: "Organizations");

            migrationBuilder.RenameTable(
                name: "News",
                newName: "Newses");

            migrationBuilder.RenameTable(
                name: "Event",
                newName: "Events");

            migrationBuilder.RenameTable(
                name: "Application",
                newName: "Applications");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Petitions",
                newName: "StarDate");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Petitions",
                newName: "FinishDate");

            migrationBuilder.RenameIndex(
                name: "IX_Petition_AuthorId",
                table: "Petitions",
                newName: "IX_Petitions_AuthorId");

            migrationBuilder.RenameColumn(
                name: "Organization name",
                table: "Organizations",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Created",
                table: "Newses",
                newName: "DateTimeCreation");

            migrationBuilder.RenameIndex(
                name: "IX_News_AuthorId",
                table: "Newses",
                newName: "IX_Newses_AuthorId");

            migrationBuilder.RenameColumn(
                name: "Start",
                table: "Events",
                newName: "StartDate");

            migrationBuilder.RenameColumn(
                name: "EventName",
                table: "Events",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "End",
                table: "Events",
                newName: "EndDate");

            migrationBuilder.RenameIndex(
                name: "IX_Event_AuthorId",
                table: "Events",
                newName: "IX_Events_AuthorId");

            migrationBuilder.RenameColumn(
                name: "Open",
                table: "Applications",
                newName: "OpenDate");

            migrationBuilder.RenameColumn(
                name: "Close",
                table: "Applications",
                newName: "CloseDate");

            migrationBuilder.RenameIndex(
                name: "IX_Application_AuthorId",
                table: "Applications",
                newName: "IX_Applications_AuthorId");

            migrationBuilder.RenameIndex(
                name: "IX_Application_AnswerId",
                table: "Applications",
                newName: "IX_Applications_AnswerId");

            migrationBuilder.AlterColumn<Guid>(
                name: "UserOrganizationId",
                table: "Users",
                type: "char(36)",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "char(36)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Login",
                table: "Users",
                type: "longtext CHARACTER SET utf8mb4",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext CHARACTER SET utf8mb4");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Petitions",
                table: "Petitions",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Organizations",
                table: "Organizations",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Newses",
                table: "Newses",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Events",
                table: "Events",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Applications",
                table: "Applications",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_AnswerId",
                table: "Applications",
                column: "AnswerId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Applications_Users_AuthorId",
                table: "Applications",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Users_AuthorId",
                table: "Events",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Newses_Users_AuthorId",
                table: "Newses",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Petitions_Users_AuthorId",
                table: "Petitions",
                column: "AuthorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Organizations_UserOrganizationId",
                table: "Users",
                column: "UserOrganizationId",
                principalTable: "Organizations",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Votes_Petitions_PetitionId",
                table: "Votes",
                column: "PetitionId",
                principalTable: "Petitions",
                principalColumn: "Id");
        }
    }
}
