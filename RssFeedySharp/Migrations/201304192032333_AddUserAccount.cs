namespace RssFeedySharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserAccount : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.UserAccounts",
                c => new
                    {
                        UserName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.UserName);
            
            AddColumn("dbo.Feeds", "User_UserName", c => c.String(maxLength: 128));
            AddForeignKey("dbo.Feeds", "User_UserName", "dbo.UserAccounts", "UserName");
            CreateIndex("dbo.Feeds", "User_UserName");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Feeds", new[] { "User_UserName" });
            DropForeignKey("dbo.Feeds", "User_UserName", "dbo.UserAccounts");
            DropColumn("dbo.Feeds", "User_UserName");
            DropTable("dbo.UserAccounts");
        }
    }
}
