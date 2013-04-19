using System.ComponentModel.DataAnnotations;

namespace RssFeedySharp.Models
{
    public class Tag
    {
        [Key]
        public string Name { get; set; }
    }
}