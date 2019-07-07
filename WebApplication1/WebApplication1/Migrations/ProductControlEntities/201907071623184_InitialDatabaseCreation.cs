namespace WebApplication1.Migrations.ProductControlEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustId = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 60),
                        Address = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.CustId);
            
            CreateTable(
                "dbo.Location",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Title = c.String(maxLength: 100),
                        SecondTitle = c.String(maxLength: 100),
                        Customer = c.String(maxLength: 60),
                        Customer_CustId = c.Int(),
                    })
                .PrimaryKey(t => t.LocationId)
                .ForeignKey("dbo.Customers", t => t.Customer_CustId)
                .Index(t => t.Customer_CustId);
            
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        CustId = c.Int(nullable: false),
                        LocationId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Customers", t => t.CustId, cascadeDelete: true)
                .ForeignKey("dbo.Location", t => t.LocationId, cascadeDelete: true)
                .Index(t => t.CustId)
                .Index(t => t.LocationId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "LocationId", "dbo.Location");
            DropForeignKey("dbo.Orders", "CustId", "dbo.Customers");
            DropForeignKey("dbo.Location", "Customer_CustId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "LocationId" });
            DropIndex("dbo.Orders", new[] { "CustId" });
            DropIndex("dbo.Location", new[] { "Customer_CustId" });
            DropTable("dbo.Orders");
            DropTable("dbo.Location");
            DropTable("dbo.Customers");
        }
    }
}
