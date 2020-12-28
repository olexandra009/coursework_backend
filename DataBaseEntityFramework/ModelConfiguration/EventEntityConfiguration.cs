using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class EventEntityConfiguration : EntityTypeConfiguration<Event>
    {
        public EventEntityConfiguration()
        {
            ToTable("Event");
            HasKey(n => n.Id);
            Property(n => n.Name).HasColumnName("Name").IsRequired();
            Property(n => n.Description).HasColumnName("Description").IsRequired();
            Property(n => n.Edited).HasColumnName("Edited").IsRequired();
            Property(n => n.StartDate).HasColumnName("Start").IsRequired();
            Property(n => n.EndDate).HasColumnName("End").IsRequired();
            Property(n => n.EmailNotification).HasColumnName("EmailNotification").IsRequired();
        }
    }
}
