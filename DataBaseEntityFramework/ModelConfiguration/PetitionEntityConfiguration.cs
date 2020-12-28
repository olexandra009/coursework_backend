using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class PetitionEntityConfiguration : EntityTypeConfiguration<Petition>
    {
        public PetitionEntityConfiguration()
        {
            ToTable("Petition");
            HasKey(n => n.Id);
            Property(n => n.Header).HasColumnName("Header").IsRequired();
            Property(n => n.Text).HasColumnName("Text").IsRequired();
            Property(n => n.StarDate).HasColumnName("Start").IsRequired();
            Property(n => n.FinishDate).HasColumnName("End").IsRequired();

        }
    }
}
