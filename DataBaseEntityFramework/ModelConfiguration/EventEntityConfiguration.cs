//using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class EventEntityConfiguration : IEntityTypeConfiguration<Event>
    {
        //public EventEntityConfiguration()
        //{
        //    ToTable("Event");
        //    HasKey(n => n.Id);
        //Property(n => n.Name).HasColumnName("Name").IsRequired();
        //Property(n => n.Description).HasColumnName("Description").IsRequired();
        //Property(n => n.Edited).HasColumnName("Edited").IsRequired();
        //Property(n => n.StartDate).HasColumnName("Start").IsRequired();
        //Property(n => n.EndDate).HasColumnName("End").IsRequired();
        //Property(n => n.EmailNotification).HasColumnName("EmailNotification").IsRequired();
        //}

        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(n => n.Id);
            builder.Property(n => n.Name).IsRequired();
            builder.Property(n => n.Description).IsRequired();
            builder.Property(n => n.Edited).IsRequired();
            builder.Property(n => n.StartDate).IsRequired();
            builder.Property(n => n.EndDate).IsRequired();
            builder.Property(n => n.EmailNotification).IsRequired();
        }
    }
}
