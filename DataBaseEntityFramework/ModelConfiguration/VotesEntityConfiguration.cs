
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class VotesEntityConfiguration : IEntityTypeConfiguration<Votes>
    {
        public void Configure(EntityTypeBuilder<Votes> builder)
        {
            builder.HasKey(cs => cs.Id);
            builder.HasAlternateKey(cs => new { cs.PetitionId, cs.UserId});
           
            //many to one Many Petition
            builder.HasOne(s => s.Petition)
                .WithMany(c => c.UserVotes)
                .HasForeignKey(p=>p.PetitionId).OnDelete(DeleteBehavior.NoAction);
            builder.HasOne(v => v.User).WithMany(u => u.VotedPetitions)
                .HasForeignKey(v => v.UserId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
