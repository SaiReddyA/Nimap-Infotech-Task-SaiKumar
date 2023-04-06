namespace WebApplication3.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateCatagoryTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Catagories",
                c => new
                    {
                        CId = c.Int(nullable: false, identity: true),
                        CatagoryName = c.String(),
                    })
                .PrimaryKey(t => t.CId);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        PId = c.Int(nullable: false, identity: true),
                        ProductName = c.String(),
                        Catagory_CId = c.Int(),
                    })
                .PrimaryKey(t => t.PId)
                .ForeignKey("dbo.Catagories", t => t.Catagory_CId)
                .Index(t => t.Catagory_CId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Products", "Catagory_CId", "dbo.Catagories");
            DropIndex("dbo.Products", new[] { "Catagory_CId" });
            DropTable("dbo.Products");
            DropTable("dbo.Catagories");
        }
    }
}
