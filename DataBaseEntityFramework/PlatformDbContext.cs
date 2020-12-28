
using System.Data.Entity;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.ModelConfiguration;
using KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Models;

namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework
{
   public class PlatformDbContext : DbContext
   {

       public PlatformDbContext() : base("CommunityInfoPlatformDB")
       {
          
       }

       public DbSet<User> Users { get; set; }
       public DbSet<Rights> Rights { get; set; }
       public DbSet<Petition> Petitions{ get; set; }
      
       public DbSet<Organization> Organizations { get; set; }
       public DbSet<News> Newses { get; set; }
       public DbSet<Event> Events { get; set; }
       public DbSet<Application> Applications { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
       {
           modelBuilder.Configurations.Add(new UserEntityConfiguration());
           modelBuilder.Configurations.Add(new RightsEntityConfiguration());
           modelBuilder.Configurations.Add(new PetitionEntityConfiguration());
           modelBuilder.Configurations.Add(new OrganizationEntityConfiguration());
           modelBuilder.Configurations.Add(new NewsEntityConfiguration());
           modelBuilder.Configurations.Add(new EventEntityConfiguration());
           modelBuilder.Configurations.Add(new ApplicationEntityConfiguration());

        }
   }
}

