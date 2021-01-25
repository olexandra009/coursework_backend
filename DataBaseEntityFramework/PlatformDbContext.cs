
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework
{
   public class PlatformDbContext : DbContext
   {
       public PlatformDbContext()
       {
       }

       public PlatformDbContext(DbContextOptions<PlatformDbContext> options)
           : base(options)
       {
           
        }
       public virtual DbSet<UserEntity> Users { get; set; }
       public virtual DbSet<PetitionEntity> Petitions{ get; set; }
       public virtual DbSet<OrganizationEntity> Organizations { get; set; }
       public virtual DbSet<NewsEntity> Newses { get; set; }
       public virtual DbSet<EventEntity> Events { get; set; }
       public virtual DbSet<ApplicationEntity> Applications { get; set; }
       public virtual DbSet<VotesEntity> Votes { get; set; }
       public virtual DbSet<MultimediaEntity> Multimedia { get; set; }
       public virtual DbSet<EmailConfirmEntity> EmailConfirm { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
           modelBuilder.ApplyConfiguration(new PetitionEntityConfiguration());
           modelBuilder.ApplyConfiguration(new OrganizationEntityConfiguration());
           modelBuilder.ApplyConfiguration(new NewsEntityConfiguration());
           modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
           modelBuilder.ApplyConfiguration(new ApplicationEntityConfiguration());
           modelBuilder.ApplyConfiguration(new VotesEntityConfiguration());
           modelBuilder.ApplyConfiguration(new MultimediaEntityConfiguration());
           modelBuilder.ApplyConfiguration(new EmailConfirmEntityConfiguration());

       }
    }
}

