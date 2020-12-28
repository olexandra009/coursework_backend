//using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        //public UserEntityConfiguration()
        //{
        //    ToTable("Users");
        //    HasKey(u => u.Id);
        //    Property(u => u.Id).HasColumnName("Id").IsRequired();
        //    Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
        //    Property(u => u.SecondName).HasColumnName("SecondName").IsOptional();
        //    Property(u => u.LastName).HasColumnName("LastName").IsRequired();
        //    Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").IsOptional();
        //    Property(u => u.Email).HasColumnName("Email").IsOptional();
        //    Property(u => u.Login).HasColumnName("Login").IsRequired();
        //    Property(u => u.Password).HasColumnName("Password").IsRequired();
        //    Property(u => u.UserOrganizationId).HasColumnName("OrganizationId").IsOptional();

        //    //one to one
        //    HasRequired(u => u.UserRights)
        //        .WithRequiredPrincipal(r => r.User)
        //        .WillCascadeOnDelete(false);

        //    //one to many
        //    HasMany(u=>u.AnswerApplications)
        //        .WithRequired(an=>an.Answerer)
        //        .HasForeignKey(an=>an.AnswerId).WillCascadeOnDelete(false);

        //    HasMany(u => u.CreatedApplications)
        //        .WithRequired(an => an.Author)
        //        .HasForeignKey(an => an.AuthorId).WillCascadeOnDelete(false);

        //    HasMany(u => u.CreatedEvents)
        //        .WithRequired(an => an.Author)
        //        .HasForeignKey(an => an.AuthorId).WillCascadeOnDelete(false);

        //    HasMany(u => u.CreatedNews)
        //        .WithRequired(an => an.Author)
        //        .HasForeignKey(an => an.AuthorId).WillCascadeOnDelete(false);

        //    HasMany(u => u.CreatedPetitions)
        //        .WithRequired(an => an.Author)
        //        .HasForeignKey(an => an.AuthorId).WillCascadeOnDelete(false);

        //    //many to many
        //    HasMany(s => s.VotedPetitions)
        //        .WithMany(c => c.UserVotes)
        //        .Map(cs =>
        //        {
        //            cs.MapLeftKey("UserId");
        //            cs.MapRightKey("PetitionId");
        //            cs.ToTable("Votes");
        //        });
        //}

        public void Configure(EntityTypeBuilder<User> builder)
        {

            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.SecondName);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.PhoneNumber);
            builder.Property(u => u.Email);
            builder.Property(u => u.Login);
            builder.Property(u => u.Password);
            builder.Property(u => u.UserOrganizationId);

            //one to one
            builder.HasOne(u => u.UserRights)
                .WithOne(r => r.User)
                .HasForeignKey<Rights>(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //one to many
            builder.HasMany(u => u.AnswerApplications)
                .WithOne(an => an.Answerer)
                .HasForeignKey(an => an.AnswerId);

            builder.HasMany(u => u.CreatedApplications)
                .WithOne(an => an.Author)
                .HasForeignKey(an => an.AuthorId);

            builder.HasMany(u => u.CreatedEvents)
                .WithOne(an => an.Author)
                .HasForeignKey(an => an.AuthorId);

            builder.HasMany(u => u.CreatedNews)
                .WithOne(an => an.Author)
                .HasForeignKey(an => an.AuthorId);

            builder.HasMany(u => u.CreatedPetitions)
                .WithOne(an => an.Author)
                .HasForeignKey(an => an.AuthorId);
        }
    }
}
