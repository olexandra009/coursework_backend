﻿// <auto-generated />
using System;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    [DbContext(typeof(PlatformDbContext))]
    partial class PlatformDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AnswerId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Close");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Open");

                    b.Property<string>("Result")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Result");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Status");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Subject");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Event", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Description");

                    b.Property<bool>("Edited")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Edited");

                    b.Property<bool>("EmailNotification")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("EmailNotification");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("End");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("EventName");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Start");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("DateTimeCreation")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Created");

                    b.Property<bool>("Edited")
                        .HasColumnType("tinyint(1)")
                        .HasColumnName("Edited");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Header");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Organization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Organization name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Petition", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("char(36)");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("End");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Header");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("Start");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4")
                        .HasColumnName("Text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Petition");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Rights", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<bool>("AddingUser")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CreateApplication")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CreateNewsAndEvents")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("CreatePetitions")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("EditRights")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("HandlingApplication")
                        .HasColumnType("tinyint(1)");

                    b.Property<bool>("ModerateNewsAndEvents")
                        .HasColumnType("tinyint(1)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.Property<bool>("VotePetitions")
                        .HasColumnType("tinyint(1)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Rights");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("SecondName")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid?>("UserOrganizationId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasIndex("UserOrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Votes", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<Guid>("PetitionId")
                        .HasColumnType("char(36)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("char(36)");

                    b.HasKey("Id");

                    b.HasAlternateKey("PetitionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Application", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", "Answerer")
                        .WithMany("AnswerApplications")
                        .HasForeignKey("AnswerId");

                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", "Author")
                        .WithMany("CreatedApplications")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answerer");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Event", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", "Author")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.News", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", "Author")
                        .WithMany("CreatedNews")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Petition", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", "Author")
                        .WithMany("CreatedPetitions")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Rights", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", "User")
                        .WithOne("UserRights")
                        .HasForeignKey("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Rights", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Organization", "UserOrganization")
                        .WithMany("Users")
                        .HasForeignKey("UserOrganizationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserOrganization");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Votes", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Petition", "Petition")
                        .WithMany("UserVotes")
                        .HasForeignKey("PetitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", "User")
                        .WithMany("VotedPetitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Petition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Organization", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.Petition", b =>
                {
                    b.Navigation("UserVotes");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.User", b =>
                {
                    b.Navigation("AnswerApplications");

                    b.Navigation("CreatedApplications");

                    b.Navigation("CreatedEvents");

                    b.Navigation("CreatedNews");

                    b.Navigation("CreatedPetitions");

                    b.Navigation("UserRights");

                    b.Navigation("VotedPetitions");
                });
#pragma warning restore 612, 618
        }
    }
}
