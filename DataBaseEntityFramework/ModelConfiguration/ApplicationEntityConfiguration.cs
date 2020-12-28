
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class ApplicationEntityConfiguration : IEntityTypeConfiguration<Application>
    {
        //public ApplicationEntityConfiguration()
        //{
        //    ToTable("Application");
        //    HasKey(n => n.Id);
        //    Property(n => n.Subject).HasColumnName("Subject").IsRequired();
        //    Property(n => n.Text).HasColumnName("Text").IsRequired();
        //    Property(n => n.OpenDate).HasColumnName("Created").IsRequired();
        //    Property(n => n.CloseDate).HasColumnName("Closed").IsOptional();
        //    Property(n => n.Status).HasColumnName("Status").IsRequired();
        //    Property(n => n.Result).HasColumnName("Result").IsOptional();
        //}

        public void Configure(EntityTypeBuilder<Application> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(n => n.Subject).IsRequired();
            builder.Property(n => n.Text).IsRequired();
            builder.Property(n => n.OpenDate).IsRequired();
            builder.Property(n => n.CloseDate);
            builder.Property(n => n.Status).IsRequired();
            builder.Property(n => n.Result);
        }
    }
}
