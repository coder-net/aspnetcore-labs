using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class Topic
    {
        public Topic() { }
        public Topic(string name, string description)
        {
            Name = name;
            Description = description;
            CreationTime = DateTime.Now;
            LastChangeTime = DateTime.Now;
            Messages = null;
        }

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public ICollection<TopicMessage> Messages { get; set; }
    }
}
