//using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class PetitionEntityConfiguration : IEntityTypeConfiguration<Petition>
    {
        //public PetitionEntityConfiguration()
        //{
        //    ToTable("Petition");
        //    HasKey(n => n.Id);
        //    Property(n => n.Header).HasColumnName("Header").IsRequired();
        //    Property(n => n.Text).HasColumnName("Text").IsRequired();
        //    Property(n => n.StarDate).HasColumnName("Start").IsRequired();
        //    Property(n => n.FinishDate).HasColumnName("End").IsRequired();

        //}
        public void Configure(EntityTypeBuilder<Petition> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Header).IsRequired();
            builder.Property(n => n.Text).IsRequired();
            builder.Property(n => n.StarDate).IsRequired();
            builder.Property(n => n.FinishDate).IsRequired();
        }
    }
}
