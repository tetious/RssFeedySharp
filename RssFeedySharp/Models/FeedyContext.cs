using System.Data.Entity;

namespace RssFeedySharp.Models
{
    public class FeedyContext : DbContext
    {
        public DbSet<Feed> Feeds { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<UserAccount> UserAccounts { get; set; }

        public FeedyContext()
            : base("FeedySharp")
        {}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feed>()
                        .HasMany(f => f.Tags)
                        .WithMany();
        }
    }
}