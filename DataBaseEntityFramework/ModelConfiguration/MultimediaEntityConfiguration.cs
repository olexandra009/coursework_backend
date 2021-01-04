
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class MultimediaEntityConfiguration : IEntityTypeConfiguration<MultimediaEntity>
    {
        public void Configure(EntityTypeBuilder<MultimediaEntity> builder)
        {
            builder.ToTable("Multimedia");
            builder.HasKey(mul => mul.Id);
            builder.Property(mul => mul.Url).IsRequired().HasColumnName("Url");
        }
    }

   
}
