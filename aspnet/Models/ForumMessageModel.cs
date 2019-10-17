using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class ForumMessageModel
    {
        [Key]
        public int ForumMessageId { get; set; }
        public DateTime CreationTime { get; set; }
        public string Text { get; set; }
        public int TopicId { get; set; }
        public TopicModel Topic { get; set; }
    }
}
