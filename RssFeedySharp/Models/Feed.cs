using System.Collections.Generic;

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
    }
}