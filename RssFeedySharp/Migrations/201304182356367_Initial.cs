namespace RssFeedySharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Feeds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Url = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Uri = c.String(),
                        CreatedDate = c.DateTime(nullable: false),
                        Description = c.String(),
                        Content = c.String(),
                        Feed_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Feeds", t => t.Feed_Id)
                .Index(t => t.Feed_Id);
            
            CreateTable(
                "dbo.Tags",
                c => new
                    {
                        Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Name);
            
            CreateTable(
                "dbo.FeedTags",
                c => new
                    {
                        Feed_Id = c.Int(nullable: false),
                        Tag_Name = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Feed_Id, t.Tag_Name })
                .ForeignKey("dbo.Feeds", t => t.Feed_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tags", t => t.Tag_Name, cascadeDelete: true)
                .Index(t => t.Feed_Id)
                .Index(t => t.Tag_Name);
            
        }
        
        public override void Down()
        {
            DropIndex("dbo.FeedTags", new[] { "Tag_Name" });
            DropIndex("dbo.FeedTags", new[] { "Feed_Id" });
            DropIndex("dbo.Items", new[] { "Feed_Id" });
            DropForeignKey("dbo.FeedTags", "Tag_Name", "dbo.Tags");
            DropForeignKey("dbo.FeedTags", "Feed_Id", "dbo.Feeds");
            DropForeignKey("dbo.Items", "Feed_Id", "dbo.Feeds");
            DropTable("dbo.FeedTags");
            DropTable("dbo.Tags");
            DropTable("dbo.Items");
            DropTable("dbo.Feeds");
        }
    }
}
