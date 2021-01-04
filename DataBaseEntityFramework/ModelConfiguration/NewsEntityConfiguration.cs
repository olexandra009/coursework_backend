using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class NewsEntityConfiguration : IEntityTypeConfiguration<NewsEntity>
    {
       public void Configure(EntityTypeBuilder<NewsEntity> builder)
        {
            builder.ToTable("News");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Header).HasColumnName("Header").IsRequired();
            builder.Property(n => n.Text).HasColumnName("Text").IsRequired();
            builder.Property(n => n.Edited).HasColumnName("Edited").IsRequired();
            builder.Property(n => n.ShowAuthor).HasColumnName("ShowAuthor").IsRequired();
            builder.Property(n => n.DateTimeCreation).HasColumnName("Created").IsRequired();

            //relationship many to one with Multimedia
            builder.HasMany(e => e.Multimedias)
                .WithOne(m => m.News)
                .HasForeignKey(m => m.NewsId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);

        }
    }
}
