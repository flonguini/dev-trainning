using Blockbuster.Core;
using System.Data.Entity.ModelConfiguration;

namespace Blockbuster.Repository.Configuration
{
    public class ClientConfiguration : EntityTypeConfiguration<Client>
    {
        public ClientConfiguration()
        {
            this.ToTable("Clients");

            this.HasKey(key => key.Id);

            this.Property(p => p.Name).HasMaxLength(150);
            this.Property(p => p.Street).HasMaxLength(150);
            this.Property(p => p.Neighborhood).HasMaxLength(150);
            this.Property(p => p.Zipcode).HasMaxLength(150);
            this.Property(p => p.City).HasMaxLength(150);
            this.Property(p => p.Cellphone).HasMaxLength(150);
            this.Property(p => p.Email).HasMaxLength(150);
            this.Property(p => p.CPF).HasMaxLength(150);
        }
    }
}
