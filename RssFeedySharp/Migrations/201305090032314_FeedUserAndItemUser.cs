namespace RssFeedySharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FeedUserAndItemUser : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FeedTags", "Feed_Id", "dbo.Feeds");
            DropForeignKey("dbo.FeedTags", "Tag_Name", "dbo.Tags");
            DropIndex("dbo.FeedTags", new[] { "Feed_Id" });
            DropIndex("dbo.FeedTags", new[] { "Tag_Name" });
            RenameColumn(table: "dbo.Feeds", name: "User_Id", newName: "UserAccount_Id");
            CreateTable(
                "dbo.UserFeeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Feed_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feeds", t => t.Feed_Id)
                .ForeignKey("dbo.UserAccounts", t => t.User_Id)
                .Index(t => t.Feed_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.UserItems",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Read = c.Boolean(nullable: false),
                        Item_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Items", t => t.Item_Id)
                .ForeignKey("dbo.UserAccounts", t => t.User_Id)
                .Index(t => t.Item_Id)
                .Index(t => t.User_Id);
            
            AddColumn("dbo.Tags", "UserFeed_Id", c => c.Int());
            AddForeignKey("dbo.Tags", "UserFeed_Id", "dbo.UserFeeds", "Id");
            CreateIndex("dbo.Tags", "UserFeed_Id");
            DropTable("dbo.FeedTags");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FeedTags",
                c => new
                    {
                        Feed_Id = c.Int(nullable: false),
                        Tag_Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Feed_Id, t.Tag_Name });
            
            DropIndex("dbo.UserItems", new[] { "User_Id" });
            DropIndex("dbo.UserItems", new[] { "Item_Id" });
            DropIndex("dbo.Tags", new[] { "UserFeed_Id" });
            DropIndex("dbo.UserFeeds", new[] { "User_Id" });
            DropIndex("dbo.UserFeeds", new[] { "Feed_Id" });
            DropForeignKey("dbo.UserItems", "User_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.UserItems", "Item_Id", "dbo.Items");
            DropForeignKey("dbo.Tags", "UserFeed_Id", "dbo.UserFeeds");
            DropForeignKey("dbo.UserFeeds", "User_Id", "dbo.UserAccounts");
            DropForeignKey("dbo.UserFeeds", "Feed_Id", "dbo.Feeds");
            DropColumn("dbo.Tags", "UserFeed_Id");
            DropTable("dbo.UserItems");
            DropTable("dbo.UserFeeds");
            RenameColumn(table: "dbo.Feeds", name: "UserAccount_Id", newName: "User_Id");
            CreateIndex("dbo.FeedTags", "Tag_Name");
            CreateIndex("dbo.FeedTags", "Feed_Id");
            AddForeignKey("dbo.FeedTags", "Tag_Name", "dbo.Tags", "Name", cascadeDelete: true);
            AddForeignKey("dbo.FeedTags", "Feed_Id", "dbo.Feeds", "Id", cascadeDelete: true);
        }
    }
}
