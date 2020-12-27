using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class RightsEntityConfiguration : EntityTypeConfiguration<Rights>
    {
        public RightsEntityConfiguration()
        {
            ToTable("Rights");
            HasKey(u => u.Id);
            Property(u => u.Id).HasColumnName("Id").IsRequired();
            Property(u => u.AddingUser).HasColumnName("AddingUser").IsRequired();
            Property(u => u.CreateApplication).HasColumnName("CreateApplication").IsRequired();
            Property(u => u.CreateNewsAndEvents).HasColumnName("CreateNewsAndEvents").IsRequired();
            Property(u => u.CreatePetitions).HasColumnName("CreatePetitions").IsRequired();
            Property(u => u.EditRights).HasColumnName("EditRights").IsRequired();
            Property(u => u.HandlingApplication).HasColumnName("HandlingApplication").IsRequired();
            Property(u => u.VotePetitions).HasColumnName("VotePetitions").IsRequired();
            Property(u => u.ModerateNewsAndEvents).HasColumnName("ModerateNewsAndEvents").IsRequired();

            //one to one
            HasRequired(r => r.User)
                .WithRequiredDependent(u => u.UserRights)
                .WillCascadeOnDelete(false);

        }
    }
}
