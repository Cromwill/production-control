namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UserList : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserToUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.AspNetUsers", "UserList_Id", c => c.Int());
            CreateIndex("dbo.AspNetUsers", "UserList_Id");
            AddForeignKey("dbo.AspNetUsers", "UserList_Id", "dbo.UserToUsers", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UserList_Id", "dbo.UserToUsers");
            DropIndex("dbo.AspNetUsers", new[] { "UserList_Id" });
            DropColumn("dbo.AspNetUsers", "UserList_Id");
            DropTable("dbo.UserToUsers");
        }
    }
}
