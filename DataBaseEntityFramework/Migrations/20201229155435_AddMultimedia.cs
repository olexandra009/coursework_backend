using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    public partial class AddMultimedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Multimedia",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "char(36)", nullable: false),
                    Url = table.Column<string>(type: "longtext CHARACTER SET utf8mb4", nullable: true),
                    EventId = table.Column<Guid>(type: "char(36)", nullable: true),
                    NewsId = table.Column<Guid>(type: "char(36)", nullable: true),
                    ApplicationId = table.Column<Guid>(type: "char(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Multimedia", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Multimedia_Application_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "Application",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Multimedia_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Multimedia_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_ApplicationId",
                table: "Multimedia",
                column: "ApplicationId");

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_EventId",
                table: "Multimedia",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Multimedia_NewsId",
                table: "Multimedia",
                column: "NewsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Multimedia");
        }
    }
}
