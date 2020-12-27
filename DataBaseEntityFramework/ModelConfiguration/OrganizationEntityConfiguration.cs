using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class OrganizationEntityConfiguration : EntityTypeConfiguration<Organization>
    {
        public OrganizationEntityConfiguration()
        {
            ToTable("Organization");
            HasKey(u => u.Id);
            Property(u => u.Id).HasColumnName("Id").IsRequired();
            Property(u => u.Name).HasColumnName("Name").IsRequired();
            Property(u => u.Address).HasColumnName("SecondName").IsOptional();
            Property(u => u.PhoneNumber).HasColumnName("PhoneNumber").IsOptional();
           
            HasMany(o=>o.Users)
                .WithOptional(u=>u.UserOrganization)
                .HasForeignKey(u=>u.UserOrganizationId)
                .WillCascadeOnDelete(false);
        }
    }
}
