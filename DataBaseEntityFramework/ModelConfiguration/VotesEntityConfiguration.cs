
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class VotesEntityConfiguration : IEntityTypeConfiguration<VotesEntity>
    {
        public void Configure(EntityTypeBuilder<VotesEntity> builder)
        {
            builder.ToTable("Votes");
            builder.HasKey(cs => cs.Id);
            builder.Property(v => v.DateTimeCreated).IsRequired(true).HasColumnName("created");
            builder.HasAlternateKey(cs => new { cs.PetitionId, cs.UserId});
           
           
            builder.HasOne(s => s.Petition)
                .WithMany(c => c.UserVotes)
                .HasForeignKey(p=>p.PetitionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(v => v.User).WithMany(u => u.VotedPetitions)
                .HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
