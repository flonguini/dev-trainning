using Blockbuster.Core;
using System.Data.Entity.ModelConfiguration;

namespace Blockbuster.Repository.Configuration
{
    public class MovieConfiguration : EntityTypeConfiguration<Movie>
    {
        public MovieConfiguration()
        {
            this.ToTable("Movies");

            this.HasKey(key => key.Id);

            this.Property(p => p.Title).HasMaxLength(150);
            this.Property(p => p.Banner).HasMaxLength(250);
        }
    }
}
