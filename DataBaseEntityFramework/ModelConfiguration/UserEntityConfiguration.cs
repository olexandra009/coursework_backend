//using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
       
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
                .HasForeignKey(an => an.AnswerId).IsRequired(false);

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
