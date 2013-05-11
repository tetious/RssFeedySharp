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

        // EF migrations generators requires a default constructor
        public FeedyContext()
            : base("FeedySharp")
        {}

        public FeedyContext(string databaseName)
            : base(databaseName)
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}