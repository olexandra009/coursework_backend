using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class PetitionEntityConfiguration : IEntityTypeConfiguration<Petition>
    {
       public void Configure(EntityTypeBuilder<Petition> builder)
        {
            builder.ToTable("Petition");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Header).HasColumnName("Header").IsRequired();
            builder.Property(n => n.Text).HasColumnName("Text").IsRequired();
            builder.Property(n => n.StarDate).HasColumnName("Start").IsRequired();
            builder.Property(n => n.FinishDate).HasColumnName("End").IsRequired();
        }
    }
}
