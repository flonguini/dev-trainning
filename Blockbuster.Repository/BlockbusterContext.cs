using Blockbuster.Core;
using Blockbuster.Repository.Configuration;
using System.Data.Entity;

namespace Blockbuster.Repository
{
    public class BlockbusterContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }
        public DbSet<Movie> Movies { get; set; }

        public BlockbusterContext() : base("name=BlockbusterConnection")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Configurations.Add(new ClientConfiguration());
            modelBuilder.Configurations.Add(new MovieConfiguration());
        }
    }
}
