using System.Data.Entity.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration
{
    class VotesEntityConfiguration : EntityTypeConfiguration<Votes>
    {
        public VotesEntityConfiguration()
        {
            ToTable("Votes");
            HasKey(v => new {v.UserId, v.PetitionId});
            HasRequired(v => v.User)
                     .WithMany(u => u.VotedPetitions)
                     .HasForeignKey(v => v.UserId);
            HasRequired(v => v.Petition)
                .WithMany(p => p.UserVotes)
                .HasForeignKey(v => v.PetitionId);
        }
    }
}
