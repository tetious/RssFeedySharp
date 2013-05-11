namespace RssFeedySharp.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RenameStuffInItem : DbMigration
    {
        public override void Up()
        {
            RenameColumn("dbo.Items", "CreatedDate", "PublishedDate");
            RenameColumn("dbo.Items", "Description", "Title");
            DropColumn("dbo.Items", "Name");
        }
        
        public override void Down()
        {
            RenameColumn("dbo.Items", "PublishedDate", "CreatedDate");
            RenameColumn("dbo.Items", "Title", "Description");
            AddColumn("dbo.Items", "Name", c => c.String());
        }
    }
}
