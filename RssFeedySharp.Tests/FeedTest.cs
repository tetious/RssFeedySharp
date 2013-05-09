using System;
using System.Linq;
using NUnit.Framework;
using RssFeedySharp.Models;

namespace RssFeedySharp.Tests
{
    [SetUpFixture]
    public class IntegrationTestsSetup
    {
        public static readonly string DatabaseName = "FeedySharp_Test";

        [SetUp]
        public void OneTimeSetup() // this will run once per test namespace
        {
            var c = new FeedyContext(DatabaseName);
            c.Database.Delete();
            c.Database.Create();
        }

    }
    
    [TestFixture]
    public class FeedTest
    {
        private FeedyContext ctx;
        
        [SetUp]
        public void Setup()
        {
            ctx = new FeedyContext(IntegrationTestsSetup.DatabaseName);
        }

        [TearDown]
        public void Cleanup()
        {
            ctx.Database.ExecuteSqlCommand("delete from Feeds");
        }

        // Sanity tests, to make sure nothing is wrong with the models
        [Test]
        public void AddFeed()
        {
            CreateSimpleFeed();

            var loadedFeed = ctx.Feeds.FirstOrDefault(f => f.Url == "http://example.com/atom.xml");
            Assert.That(loadedFeed, Is.Not.Null);
            Assert.That(loadedFeed.Name, Is.EqualTo("Test Feed"));
        }

        private void CreateSimpleFeed()
        {
            var feed = new Feed {Name = "Test Feed", Url = "http://example.com/atom.xml"};
            ctx.Feeds.Add(feed);
            ctx.SaveChanges();
        }

        [Test]
        public void UpdateFeed()
        {
            CreateSimpleFeed();

            var loadedFeed = ctx.Feeds.FirstOrDefault(f => f.Url == "http://example.com/atom.xml");
            loadedFeed.Name = "hi";
            ctx.SaveChanges();

            var updatedFeed = ctx.Feeds.FirstOrDefault(f => f.Url == "http://example.com/atom.xml");
            Assert.That(updatedFeed, Is.Not.Null);
            Assert.That(updatedFeed.Name, Is.EqualTo("hi"));
        }

        [Test]
        public void DeleteFeed()
        {
            CreateSimpleFeed();

            var loadedFeed = ctx.Feeds.FirstOrDefault(f => f.Url == "http://example.com/atom.xml");
            ctx.Feeds.Remove(loadedFeed);
            ctx.SaveChanges();

            var deletedFeed = ctx.Feeds.FirstOrDefault(f => f.Url == "http://example.com/atom.xml");
            Assert.That(deletedFeed, Is.Null);
        }
    }
}
