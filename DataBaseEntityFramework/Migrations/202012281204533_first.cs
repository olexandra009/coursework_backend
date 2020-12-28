namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class first : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Application",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                        AnswerId = c.Guid(nullable: false),
                        Subject = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Status = c.String(nullable: false),
                        Result = c.String(),
                        Created = c.DateTime(nullable: false),
                        Closed = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AnswerId)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId)
                .Index(t => t.AnswerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false),
                        SecondName = c.String(),
                        LastName = c.String(nullable: false),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Login = c.String(nullable: false),
                        Password = c.String(nullable: false),
                        OrganizationId = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Organization", t => t.OrganizationId)
                .Index(t => t.OrganizationId);
            
            CreateTable(
                "dbo.Event",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        Description = c.String(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        Edited = c.Boolean(nullable: false),
                        EmailNotification = c.Boolean(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.News",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Header = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Edited = c.Boolean(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Petition",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Header = c.String(nullable: false),
                        Text = c.String(nullable: false),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        AuthorId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.AuthorId)
                .Index(t => t.AuthorId);
            
            CreateTable(
                "dbo.Organization",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Name = c.String(nullable: false),
                        SecondName = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Rights",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AddingUser = c.Boolean(nullable: false),
                        EditRights = c.Boolean(nullable: false),
                        CreatePetitions = c.Boolean(nullable: false),
                        VotePetitions = c.Boolean(nullable: false),
                        CreateNewsAndEvents = c.Boolean(nullable: false),
                        ModerateNewsAndEvents = c.Boolean(nullable: false),
                        CreateApplication = c.Boolean(nullable: false),
                        HandlingApplication = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.Votes",
                c => new
                    {
                        UserId = c.Guid(nullable: false),
                        PetitionId = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.PetitionId })
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.Petition", t => t.PetitionId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.PetitionId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Votes", "PetitionId", "dbo.Petition");
            DropForeignKey("dbo.Votes", "UserId", "dbo.Users");
            DropForeignKey("dbo.Rights", "Id", "dbo.Users");
            DropForeignKey("dbo.Users", "OrganizationId", "dbo.Organization");
            DropForeignKey("dbo.Petition", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.News", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Event", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Application", "AuthorId", "dbo.Users");
            DropForeignKey("dbo.Application", "AnswerId", "dbo.Users");
            DropIndex("dbo.Votes", new[] { "PetitionId" });
            DropIndex("dbo.Votes", new[] { "UserId" });
            DropIndex("dbo.Rights", new[] { "Id" });
            DropIndex("dbo.Petition", new[] { "AuthorId" });
            DropIndex("dbo.News", new[] { "AuthorId" });
            DropIndex("dbo.Event", new[] { "AuthorId" });
            DropIndex("dbo.Users", new[] { "OrganizationId" });
            DropIndex("dbo.Application", new[] { "AnswerId" });
            DropIndex("dbo.Application", new[] { "AuthorId" });
            DropTable("dbo.Votes");
            DropTable("dbo.Rights");
            DropTable("dbo.Organization");
            DropTable("dbo.Petition");
            DropTable("dbo.News");
            DropTable("dbo.Event");
            DropTable("dbo.Users");
            DropTable("dbo.Application");
        }
    }
}
