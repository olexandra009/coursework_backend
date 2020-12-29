using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.ToTable("Event");
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Name).HasColumnName("EventName").IsRequired();
            builder.Property(n => n.Description).HasColumnName("Description").IsRequired();
            builder.Property(n => n.Edited).HasColumnName("Edited").IsRequired();
            builder.Property(n => n.StartDate).HasColumnName("Start").IsRequired();
            builder.Property(n => n.EndDate).HasColumnName("End").IsRequired();
            builder.Property(n => n.EmailNotification).HasColumnName("EmailNotification").IsRequired();
        }
    }
}
