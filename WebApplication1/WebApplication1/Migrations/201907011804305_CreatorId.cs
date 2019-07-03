namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatorId : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AspNetUsers", "UserList_Id", "dbo.UserToUsers");
            DropIndex("dbo.AspNetUsers", new[] { "UserList_Id" });
            AddColumn("dbo.AspNetUsers", "CreatorId", c => c.String());
            DropColumn("dbo.AspNetUsers", "UserList_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AspNetUsers", "UserList_Id", c => c.Int());
            DropColumn("dbo.AspNetUsers", "CreatorId");
            CreateIndex("dbo.AspNetUsers", "UserList_Id");
            AddForeignKey("dbo.AspNetUsers", "UserList_Id", "dbo.UserToUsers", "Id");
        }
    }
}
