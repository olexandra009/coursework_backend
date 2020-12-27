using System;
using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class UserEntityConfiguration : EntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
            ToTable("Users");
            HasKey(u => u.Id);
            Property(u => u.Id).HasColumnName("Id").IsRequired();
            Property(u => u.FirstName).HasColumnName("FirstName").IsRequired();
            Property(u => u.SecondName).HasColumnName("SecondName").IsOptional();
            Property(u => u.LastName).HasColumnName("LastName").IsRequired();
            Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").IsOptional();
            Property(u => u.Email).HasColumnName("Email").IsOptional();
            Property(u => u.Login).HasColumnName("Login").IsRequired();
            Property(u => u.Password).HasColumnName("Password").IsRequired();

            //one to one
            HasRequired(u => u.UserRights)
                .WithRequiredPrincipal(r => r.User)
                .WillCascadeOnDelete(false);


            //many to many
            HasMany(u=>u.VotedPetitions)
                .WithRequired(p=>p.Author)
                .HasForeignKey(p=>p.Author.Id)
                .WillCascadeOnDelete(false);

            //one to many
            HasMany(u=>u.AnswerApplications)
                .WithRequired(an=>an.Answerer)
                .HasForeignKey(an=>an.Answerer.Id).WillCascadeOnDelete(false);

            HasMany(u => u.CreatedApplications)
                .WithRequired(an => an.Author)
                .HasForeignKey(an => an.Author.Id).WillCascadeOnDelete(false);

            HasMany(u => u.CreatedEvents)
                .WithRequired(an => an.Author)
                .HasForeignKey(an => an.Author.Id).WillCascadeOnDelete(false);

            HasMany(u => u.CreatedNews)
                .WithRequired(an => an.Author)
                .HasForeignKey(an => an.Author.Id).WillCascadeOnDelete(false);

            HasMany(u => u.CreatedPetitions)
                .WithRequired(an => an.Author)
                .HasForeignKey(an => an.Author.Id).WillCascadeOnDelete(false);
        }
    }
}
