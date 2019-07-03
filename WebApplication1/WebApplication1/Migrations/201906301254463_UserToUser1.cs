namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserToUser1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserToUsers", "UsersId", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserToUsers", "UsersId");
        }
    }
}
