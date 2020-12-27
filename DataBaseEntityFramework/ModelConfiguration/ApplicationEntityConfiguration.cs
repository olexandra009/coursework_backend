using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class ApplicationEntityConfiguration : EntityTypeConfiguration<Application>
    {
        public ApplicationEntityConfiguration()
        {
            ToTable("Application");
            HasKey(n => n.Id);
            Property(n => n.Subject).HasColumnName("Subject").IsRequired();
            Property(n => n.Text).HasColumnName("Text").IsRequired();
            Property(n => n.OpenDate).HasColumnName("Created").IsRequired();
            Property(n => n.CloseDate).HasColumnName("Closed").IsOptional();
            Property(n => n.Status).HasColumnName("Status").IsRequired();
            Property(n => n.Result).HasColumnName("Result").IsOptional();
        
        }
    }
}
