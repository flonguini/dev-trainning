namespace Blockbuster.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateClientTypeConfiguration : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Clients", "Name", c => c.String(maxLength: 150));
            AlterColumn("dbo.Clients", "Street", c => c.String(maxLength: 150));
            AlterColumn("dbo.Clients", "Neighborhood", c => c.String(maxLength: 150));
            AlterColumn("dbo.Clients", "Zipcode", c => c.String(maxLength: 150));
            AlterColumn("dbo.Clients", "City", c => c.String(maxLength: 150));
            AlterColumn("dbo.Clients", "Cellphone", c => c.String(maxLength: 150));
            AlterColumn("dbo.Clients", "Email", c => c.String(maxLength: 150));
            AlterColumn("dbo.Clients", "CPF", c => c.String(maxLength: 150));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Clients", "CPF", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Email", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Cellphone", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "City", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Zipcode", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Neighborhood", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Street", c => c.String(maxLength: 4000));
            AlterColumn("dbo.Clients", "Name", c => c.String(maxLength: 4000));
        }
    }
}
