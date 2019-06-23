namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Locations", "SecondTitle", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Locations", "SecondTitle");
        }
    }
}
