using System.Collections.Generic;
using System.Linq;

namespace RssFeedySharp.Models
{
    public class UserFeed : IntBasedEntity
    {
        public virtual Feed Feed { get; set; }
        public virtual UserAccount User { get; set; }
        public virtual List<Tag> Tags { get; set; }     
    }

    public class Feed : IntBasedEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual List<Item> Items { get; set; }

        public Item GetLatestItem()
        {
            return Items.OrderByDescending(i => i.PublishedDate).FirstOrDefault();
        }

        public void AddNewItems(IEnumerable<Item> items)
        {
            var itemsToAdd = items.Where(i => i.PublishedDate > GetLatestItem().PublishedDate);
            using (var context = new FeedyContext())
            {
                Items.AddRange(itemsToAdd);
                context.SaveChanges();
            }
        }
    }
}