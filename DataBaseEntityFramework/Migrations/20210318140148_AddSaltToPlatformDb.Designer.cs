﻿// <auto-generated />
using System;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    [DbContext(typeof(PlatformDbContext))]
    [Migration("20210318140148_AddSaltToPlatformDb")]
    partial class AddSaltToPlatformDb
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "6.0.0-preview.2.21154.2")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.ApplicationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("AnswerId")
                        .HasColumnType("integer");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CloseDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("Close");

                    b.Property<DateTime>("OpenDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("Open");

                    b.Property<string>("Result")
                        .HasColumnType("text")
                        .HasColumnName("Result");

                    b.Property<int>("Status")
                        .HasColumnType("integer")
                        .HasColumnName("Status");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Subject");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Text");

                    b.HasKey("Id");

                    b.HasIndex("AnswerId");

                    b.HasIndex("AuthorId");

                    b.ToTable("Application");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.EmailConfirmEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Code");

                    b.Property<int>("UserKey")
                        .HasColumnType("integer")
                        .HasColumnName("UserId");

                    b.HasKey("Id")
                        .HasName("Id");

                    b.HasAlternateKey("UserKey");

                    b.ToTable("EmailConfirm");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.EventEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Description");

                    b.Property<bool>("Edited")
                        .HasColumnType("boolean")
                        .HasColumnName("Edited");

                    b.Property<bool>("EmailNotification")
                        .HasColumnType("boolean")
                        .HasColumnName("EmailNotification");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("End");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("EventName");

                    b.Property<bool>("ShowAuthor")
                        .HasColumnType("boolean")
                        .HasColumnName("ShowAuthor");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("Start");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Event");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.MultimediaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ApplicationId")
                        .HasColumnType("integer");

                    b.Property<int?>("EventId")
                        .HasColumnType("integer");

                    b.Property<int?>("NewsId")
                        .HasColumnType("integer");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Url");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationId");

                    b.HasIndex("EventId");

                    b.HasIndex("NewsId");

                    b.ToTable("Multimedia");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.NewsEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("DateTimeCreation")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("Created");

                    b.Property<bool>("Edited")
                        .HasColumnType("boolean")
                        .HasColumnName("Edited");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Header");

                    b.Property<bool>("ShowAuthor")
                        .HasColumnType("boolean")
                        .HasColumnName("ShowAuthor");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("News");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.OrganizationEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .HasColumnType("text")
                        .HasColumnName("Address");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Organization_name");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text")
                        .HasColumnName("PhoneNumber");

                    b.HasKey("Id");

                    b.ToTable("Organization");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.PetitionEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Answer")
                        .HasColumnType("text")
                        .HasColumnName("Answer");

                    b.Property<int>("AuthorId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("FinishDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("End");

                    b.Property<string>("Header")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Header");

                    b.Property<DateTime>("StarDate")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("Start");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("Text");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.ToTable("Petition");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<bool>("EmailConfirm")
                        .HasColumnType("boolean");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("text");

                    b.Property<string>("Role")
                        .HasColumnType("text");

                    b.Property<string>("Salt")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("SecondName")
                        .HasColumnType("text");

                    b.Property<int?>("UserOrganizationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("UserOrganizationId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.VotesEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateTimeCreated")
                        .HasColumnType("timestamp without time zone")
                        .HasColumnName("created");

                    b.Property<int>("PetitionId")
                        .HasColumnType("integer");

                    b.Property<int>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasAlternateKey("PetitionId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("Votes");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.ApplicationEntity", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", "Answerer")
                        .WithMany("AnswerApplications")
                        .HasForeignKey("AnswerId");

                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", "Author")
                        .WithMany("CreatedApplications")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Answerer");

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.EmailConfirmEntity", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", "User")
                        .WithOne("EmailConfirmEntity")
                        .HasForeignKey("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.EmailConfirmEntity", "UserKey")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.EventEntity", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", "Author")
                        .WithMany("CreatedEvents")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.MultimediaEntity", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.ApplicationEntity", "Application")
                        .WithMany("Multimedias")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.EventEntity", "Event")
                        .WithMany("Multimedias")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientCascade);

                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.NewsEntity", "News")
                        .WithMany("Multimedias")
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Application");

                    b.Navigation("Event");

                    b.Navigation("News");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.NewsEntity", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", "Author")
                        .WithMany("CreatedNews")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.PetitionEntity", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", "Author")
                        .WithMany("CreatedPetitions")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.OrganizationEntity", "UserOrganization")
                        .WithMany("Users")
                        .HasForeignKey("UserOrganizationId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("UserOrganization");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.VotesEntity", b =>
                {
                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.PetitionEntity", "Petition")
                        .WithMany("UserVotes")
                        .HasForeignKey("PetitionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", "User")
                        .WithMany("VotedPetitions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Petition");

                    b.Navigation("User");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.ApplicationEntity", b =>
                {
                    b.Navigation("Multimedias");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.EventEntity", b =>
                {
                    b.Navigation("Multimedias");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.NewsEntity", b =>
                {
                    b.Navigation("Multimedias");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.OrganizationEntity", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.PetitionEntity", b =>
                {
                    b.Navigation("UserVotes");
                });

            modelBuilder.Entity("KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models.UserEntity", b =>
                {
                    b.Navigation("AnswerApplications");

                    b.Navigation("CreatedApplications");

                    b.Navigation("CreatedEvents");

                    b.Navigation("CreatedNews");

                    b.Navigation("CreatedPetitions");

                    b.Navigation("EmailConfirmEntity");

                    b.Navigation("VotedPetitions");
                });
#pragma warning restore 612, 618
        }
    }
}
