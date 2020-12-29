using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class RightsEntityConfiguration : IEntityTypeConfiguration<Rights>
    {
        public void Configure(EntityTypeBuilder<Rights> builder)
        {
            builder.ToTable("Rights");
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
        }
    }
}
