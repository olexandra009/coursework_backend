using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.ToTable("Organization");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Name).HasColumnName("Organization name").IsRequired();
            builder.Property(u => u.Address).HasColumnName("Address").IsRequired(false);
            builder.Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").IsRequired(false);
            builder.HasMany(o => o.Users)
                .WithOne(u => u.UserOrganization)
                .HasForeignKey(u => u.UserOrganizationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
