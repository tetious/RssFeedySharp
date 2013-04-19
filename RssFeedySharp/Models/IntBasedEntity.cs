using System.ComponentModel.DataAnnotations;

namespace RssFeedySharp.Models
{
    public abstract class IntBasedEntity
    {
        [Key]
        public int Id { get; set; }
    }
}