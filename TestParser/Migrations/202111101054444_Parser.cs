namespace TestParser.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Parser : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ItemModels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Price = c.String(),
                        City = c.String(),
                        ItemRef = c.String(),
                        PhotoRef = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.TestObjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestObjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.ItemModels");
        }
    }
}
