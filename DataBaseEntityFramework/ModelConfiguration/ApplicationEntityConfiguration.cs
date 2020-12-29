using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class ApplicationEntityConfiguration : IEntityTypeConfiguration<Application>
    {
       public void Configure(EntityTypeBuilder<Application> builder)
       {
            builder.ToTable("Application");
            builder.HasKey(a => a.Id);
            builder.Property(n => n.Subject).HasColumnName("Subject").IsRequired();
            builder.Property(n => n.Text).HasColumnName("Text").IsRequired();
            builder.Property(n => n.OpenDate).HasColumnName("Open").IsRequired();
            builder.Property(n => n.CloseDate).HasColumnName("Close").IsRequired(false);
            builder.Property(n => n.Status).HasColumnName("Status").IsRequired();
            builder.Property(n => n.Result).HasColumnName("Result").IsRequired(false);

            //relationship many to one with Multimedia
            builder.HasMany(e => e.Multimedias)
                .WithOne(m => m.Application)
                .HasForeignKey(m => m.ApplicationId);
        }
    }
}
