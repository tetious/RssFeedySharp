using System;

namespace RssFeedySharp.Models
{
    public class UserItem : IntBasedEntity
    {
        public virtual Item Item { get; set; }
        public virtual UserAccount User { get; set; }
        public bool Read { get; set; }
    }

    public class Item : IntBasedEntity
    {
        public string Uri { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}