using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class NewsEntityConfiguration : IEntityTypeConfiguration<News>
    {
       public void Configure(EntityTypeBuilder<News> builder)
        {
            builder.ToTable("News");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Header).HasColumnName("Header").IsRequired();
            builder.Property(n => n.Text).HasColumnName("Text").IsRequired();
            builder.Property(n => n.Edited).HasColumnName("Edited").IsRequired();
            builder.Property(n => n.DateTimeCreation).HasColumnName("Created").IsRequired();
        }
    }
}
