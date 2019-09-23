using Blockbuster.Core;
using System.Data.Entity;

namespace Blockbuster.Repository
{
    public class BlockbusterContext : DbContext
    {
        public DbSet<Client> Clients { get; set; }

        public BlockbusterContext() : base("name=BlockbusterConnection")
        {

        }
    }
}
