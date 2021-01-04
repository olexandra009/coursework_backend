using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class EventEntityConfiguration : IEntityTypeConfiguration<EventEntity>
    {
        public void Configure(EntityTypeBuilder<EventEntity> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Name).HasColumnName("EventName").IsRequired();
            builder.Property(n => n.Description).HasColumnName("Description").IsRequired();
            builder.Property(n => n.Edited).HasColumnName("Edited").IsRequired();
            builder.Property(n => n.ShowAuthor).HasColumnName("ShowAuthor").IsRequired();
            builder.Property(n => n.StartDate).HasColumnName("Start").IsRequired();
            builder.Property(n => n.EndDate).HasColumnName("End").IsRequired();
            builder.Property(n => n.EmailNotification).HasColumnName("EmailNotification").IsRequired();

            //relationship many to one with Multimedia
            builder.HasMany(e => e.Multimedias)
                .WithOne(m => m.Event)
                .HasForeignKey(m => m.EventId)
                .OnDelete(DeleteBehavior.ClientCascade)
                .IsRequired(false);

        }
    }
}
