namespace Blockbuster.Repository.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blockbuster.Repository.BlockbusterContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            //SetSqlGenerator("", new );
        }

        protected override void Seed(Blockbuster.Repository.BlockbusterContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
