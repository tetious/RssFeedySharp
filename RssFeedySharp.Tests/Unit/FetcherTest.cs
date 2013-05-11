using System.Linq;
using NUnit.Framework;
using RssFeedySharp.Lib;
using RssFeedySharp.Models;

namespace RssFeedySharp.Tests.Unit
{
    [TestFixture]
    public class FetcherTest
    {
        [Test]
        public void CanFetchItemsRss()
        {
            var fetcher = new FeedFetcher();
            var items = fetcher.FetchItems(new Feed {Url = "../../data/glcom-rss.xml"});
            Assert.That(items, Is.Not.Null);
            var latest = items.OrderByDescending(i => i.PublishedDate).First();
            Assert.That(latest.Title, Is.EqualTo("Loopback success"));
        }

        [Test]
        public void CanFetchItemsAtom()
        {
            var fetcher = new FeedFetcher();
            var items = fetcher.FetchItems(new Feed { Url = "../../data/glcom-atom.xml" });
            Assert.That(items, Is.Not.Null);
            var latest = items.OrderByDescending(i => i.PublishedDate).First();
            Assert.That(latest.Title, Is.EqualTo("Loopback success"));
        }

    }
}