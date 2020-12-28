using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class NewsEntityConfiguration : EntityTypeConfiguration<News>
    {
        public NewsEntityConfiguration()
        {
            ToTable("News");
            HasKey(n => n.Id);
            Property(n => n.Header).HasColumnName("Header").IsRequired();
            Property(n => n.Text).HasColumnName("Text").IsRequired();
            Property(n => n.Edited).HasColumnName("Edited").IsRequired();
            Property(n => n.DateTimeCreation).HasColumnName("Created").IsRequired();
        }
    }
}
