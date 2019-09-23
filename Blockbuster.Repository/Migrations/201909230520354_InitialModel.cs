namespace Blockbuster.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 4000),
                        Street = c.String(maxLength: 4000),
                        Neighborhood = c.String(maxLength: 4000),
                        Zipcode = c.String(maxLength: 4000),
                        City = c.String(maxLength: 4000),
                        Cellphone = c.String(maxLength: 4000),
                        Email = c.String(maxLength: 4000),
                        CPF = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
