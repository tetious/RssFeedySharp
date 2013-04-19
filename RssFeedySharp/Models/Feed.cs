using System.Collections.Generic;

namespace RssFeedySharp.Models
{
    public class Feed : IntBasedEntity
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public virtual List<Item> Items { get; set; }
        public virtual List<Tag> Tags { get; set; }
    }
}