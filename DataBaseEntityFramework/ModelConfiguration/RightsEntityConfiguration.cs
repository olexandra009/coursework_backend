//using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class RightsEntityConfiguration : IEntityTypeConfiguration<Rights>
    {
        //public RightsEntityConfiguration()
        //{
        //    ToTable("Rights");
        //    HasKey(u => u.Id);
        //    Property(u => u.Id).HasColumnName("Id").IsRequired();
        //    Property(u => u.AddingUser).HasColumnName("AddingUser").IsRequired();
        //    Property(u => u.CreateApplication).HasColumnName("CreateApplication").IsRequired();
        //    Property(u => u.CreateNewsAndEvents).HasColumnName("CreateNewsAndEvents").IsRequired();
        //    Property(u => u.CreatePetitions).HasColumnName("CreatePetitions").IsRequired();
        //    Property(u => u.EditRights).HasColumnName("EditRights").IsRequired();
        //    Property(u => u.HandlingApplication).HasColumnName("HandlingApplication").IsRequired();
        //    Property(u => u.VotePetitions).HasColumnName("VotePetitions").IsRequired();
        //    Property(u => u.ModerateNewsAndEvents).HasColumnName("ModerateNewsAndEvents").IsRequired();

        //    //one to one
        //    HasRequired(r => r.User)
        //        .WithRequiredDependent(u => u.UserRights)
        //        .WillCascadeOnDelete(false);

        //}

        public void Configure(EntityTypeBuilder<Rights> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.AddingUser).IsRequired();
            builder.Property(u => u.CreateApplication).IsRequired();
            builder.Property(u => u.CreateNewsAndEvents).IsRequired();
            builder.Property(u => u.CreatePetitions).IsRequired();
            builder.Property(u => u.EditRights).IsRequired();
            builder.Property(u => u.HandlingApplication).IsRequired();
            builder.Property(u => u.VotePetitions).IsRequired();
            builder.Property(u => u.ModerateNewsAndEvents).IsRequired();

            ////one to one
            //builder.HasOne(r => r.User)
            //    .WithOne(u => u.UserRights)
            //    .
            //    .IsRequired()
            //    .WillCascadeOnDelete(false);
        }
    }
}
