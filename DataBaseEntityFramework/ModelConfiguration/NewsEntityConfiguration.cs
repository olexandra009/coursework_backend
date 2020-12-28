//using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class NewsEntityConfiguration : IEntityTypeConfiguration<News>
    {
        //public NewsEntityConfiguration()
        //{
        //    ToTable("News");
        //    HasKey(n => n.Id);
        //    Property(n => n.Header).HasColumnName("Header").IsRequired();
        //    Property(n => n.Text).HasColumnName("Text").IsRequired();
        //    Property(n => n.Edited).HasColumnName("Edited").IsRequired();
        //    Property(n => n.DateTimeCreation).HasColumnName("Created").IsRequired();
        //}

        public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Header).IsRequired();
            builder.Property(n => n.Text).IsRequired();
            builder.Property(n => n.Edited).IsRequired();
            builder.Property(n => n.DateTimeCreation).IsRequired();
        }
    }
}
