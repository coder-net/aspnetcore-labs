using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class Topic
    {
        public Topic()
        {
            Messages = new List<Comment<Topic>>();
        }
        public Topic(string name)
        {
            TopicName = name;
            CreationTime = DateTime.Now;
            LastChangeTime = DateTime.Now;
            Messages = new List<Comment<Topic>>();
        }

        [Key]
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }

        public ICollection<Comment<Topic>> Messages { get; set; }
    }
}
