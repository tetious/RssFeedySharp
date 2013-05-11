using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Xml;
using RssFeedySharp.Models;
using System.Net.Http;
using System.Linq;

namespace RssFeedySharp.Lib
{
    public class FeedFetcherMgr
    {
        
    }

    public static class SyndicationExtensions
    {
        public static Item AsFeedyItem(this SyndicationItem syndicationItem)
        {
            return new Item
                {
                    Content = syndicationItem.Summary.Text,
                    PublishedDate = syndicationItem.PublishDate.Date.ToUniversalTime(),
                    Title = syndicationItem.Title.Text,
                    Uri = syndicationItem.Id
                };
        }
    }

    public class FeedFetcher
    {
        private HttpClient http;

        public FeedFetcher()
        {
            http = new HttpClient();
        }

        public IEnumerable<Item> FetchItems(Feed feed)
        {
            var syndicationFeed = SyndicationFeed.Load(XmlReader.Create(feed.Url));
            if (syndicationFeed == null || !syndicationFeed.Items.Any())
                return null;

            return syndicationFeed.Items.Select(i => i.AsFeedyItem());
        }
    }
}