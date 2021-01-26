using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    public class EmailConfirmEntityConfiguration : IEntityTypeConfiguration<EmailConfirmEntity>
    {
        public void Configure(EntityTypeBuilder<EmailConfirmEntity> builder)
        {
            builder.ToTable("EmailConfirm");
            builder.HasKey(e => e.Id).HasName("Id");
            builder.Property(e => e.UserKey).HasColumnName("UserId").IsRequired();
            builder.HasAlternateKey(e => e.UserKey);
            builder.Property(e => e.Code).HasColumnName("Code").IsRequired();

        }
    }
}
