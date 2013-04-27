using System.Collections.Generic;

namespace RssFeedySharp.Models
{
    public class UserAccount : IntBasedEntity
    {
        public string UserName { get; set; }
        public virtual List<Feed> Feeds { get; set; }
    }
}