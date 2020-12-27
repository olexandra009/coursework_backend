namespace KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.PlatformDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(KMA.Coursework.CommunicationPlatform.DataBaseEntityFramework.PlatformDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
