using System;

namespace RssFeedySharp.Models
{
    public class Item : IntBasedEntity
    {
        public string Name { get; set; }
        public string Uri { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
    }
}