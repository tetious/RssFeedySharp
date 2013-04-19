using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RssFeedySharp.Models
{
    public class UserAccount
    {
        [Key]
        public string UserName { get; set; }
        public virtual List<Feed> Feeds { get; set; }
        
        // todo make auth/auth

    }
}