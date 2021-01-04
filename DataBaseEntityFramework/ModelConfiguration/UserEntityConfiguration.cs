using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.FirstName).IsRequired();
            builder.Property(u => u.SecondName).IsRequired(false);
            builder.Property(u => u.LastName).IsRequired();
            builder.Property(u => u.PhoneNumber).IsRequired(false);
            builder.Property(u => u.Email).IsRequired(false);
            builder.Property(u => u.Login).IsRequired();
            builder.Property(u => u.Password).IsRequired();
            builder.Property(u => u.UserOrganizationId).IsRequired(false); 

           
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
