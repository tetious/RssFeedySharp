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
        public string Name { get; set; }
        public string Uri { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}