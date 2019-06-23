namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Locations", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Locations", new[] { "ApplicationUser_Id" });
            DropTable("dbo.Locations");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Locations",
                c => new
                    {
                        LocationId = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SecondTitle = c.String(),
                        Customer = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.LocationId);
            
            CreateIndex("dbo.Locations", "ApplicationUser_Id");
            AddForeignKey("dbo.Locations", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
        }
    }
}
