
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;
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
       public virtual DbSet<User> Users { get; set; }
       public virtual DbSet<Rights> Rights { get; set; }
       public virtual DbSet<Petition> Petitions{ get; set; }
       public virtual DbSet<Organization> Organizations { get; set; }
       public virtual DbSet<News> Newses { get; set; }
       public virtual DbSet<Event> Events { get; set; }
       public virtual DbSet<Application> Applications { get; set; }
       public virtual DbSet<Votes> Votes { get; set; }

      

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
           base.OnModelCreating(modelBuilder);
           modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
           modelBuilder.ApplyConfiguration(new RightsEntityConfiguration());
           modelBuilder.ApplyConfiguration(new PetitionEntityConfiguration());
           modelBuilder.ApplyConfiguration(new OrganizationEntityConfiguration());
           modelBuilder.ApplyConfiguration(new NewsEntityConfiguration());
           modelBuilder.ApplyConfiguration(new EventEntityConfiguration());
           modelBuilder.ApplyConfiguration(new ApplicationEntityConfiguration());
           modelBuilder.ApplyConfiguration(new VotesEntityConfiguration());


        }
    }
}

