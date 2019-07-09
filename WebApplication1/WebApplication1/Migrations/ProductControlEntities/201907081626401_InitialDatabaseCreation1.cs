namespace WebApplication1.Migrations.ProductControlEntities
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDatabaseCreation1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "UserId", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "UserId");
        }
    }
}
