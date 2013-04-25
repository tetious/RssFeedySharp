namespace RssFeedySharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ShiftToWebMatrixAuth : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Feeds", "User_UserName", "dbo.UserAccounts");
            DropPrimaryKey("dbo.UserAccounts", new[] { "UserName" });
            DropIndex("dbo.Feeds", new[] { "User_UserName" });
            AddColumn("dbo.Feeds", "User_Id", c => c.Int());
            AddColumn("dbo.UserAccounts", "Id", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.UserAccounts", "UserName", c => c.String());
            AddPrimaryKey("dbo.UserAccounts", "Id");
            AddForeignKey("dbo.Feeds", "User_Id", "dbo.UserAccounts", "Id");
            CreateIndex("dbo.Feeds", "User_Id");
            DropColumn("dbo.Feeds", "User_UserName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Feeds", "User_UserName", c => c.String(maxLength: 128));
            DropIndex("dbo.Feeds", new[] { "User_Id" });
            DropForeignKey("dbo.Feeds", "User_Id", "dbo.UserAccounts");
            DropPrimaryKey("dbo.UserAccounts", new[] { "Id" });
            AddPrimaryKey("dbo.UserAccounts", "UserName");
            AlterColumn("dbo.UserAccounts", "UserName", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.UserAccounts", "Id");
            DropColumn("dbo.Feeds", "User_Id");
            CreateIndex("dbo.Feeds", "User_UserName");
            AddForeignKey("dbo.Feeds", "User_UserName", "dbo.UserAccounts", "UserName");
        }
    }
}
