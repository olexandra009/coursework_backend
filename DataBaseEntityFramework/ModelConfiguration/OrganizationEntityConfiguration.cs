//using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class OrganizationEntityConfiguration : IEntityTypeConfiguration<Organization>
    {
        //public OrganizationEntityConfiguration()
        //{
        //    ToTable("Organization");
        //    HasKey(u => u.Id);
        //    Property(u => u.Id).HasColumnName("Id").IsRequired();
        //    Property(u => u.Name).HasColumnName("Name").IsRequired();
        //    Property(u => u.Address).HasColumnName("SecondName").IsOptional();
        //    Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").IsOptional();
           
            
        //}

        public void Configure(EntityTypeBuilder<Organization> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).IsRequired();
            builder.Property(u => u.Name).IsRequired();
            builder.Property(u => u.Address);
            builder.Property(u => u.PhoneNumber);
            builder.HasMany(o => o.Users)
                .WithOne(u => u.UserOrganization)
                .HasForeignKey(u => u.UserOrganizationId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
