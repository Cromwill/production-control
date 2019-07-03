namespace WebApplication1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreatUsers : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.UserToUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.UserToUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        UsersId = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
