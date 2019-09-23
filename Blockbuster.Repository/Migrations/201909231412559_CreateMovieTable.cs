namespace Blockbuster.Repository.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateMovieTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Movies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 150),
                        Year = c.Int(),
                        Rate = c.Int(),
                        ReleaseDate = c.DateTime(nullable: false),
                        RuntimeInMinutes = c.Int(nullable: false),
                        Banner = c.String(maxLength: 250),
                        QuantityInStock = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Movies");
        }
    }
}
