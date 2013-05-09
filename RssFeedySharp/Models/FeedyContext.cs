using System.Data.Entity;

namespace RssFeedySharp.Models
{
    public class FeedyContext : DbContext
    {
        public DbSet<UserFeed> UserFeeds { get; set; }
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserItem> UserItems { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public FeedyContext(string databaseName = "FeedySharp")
            : base(databaseName)
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}