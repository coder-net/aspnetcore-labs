using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class TopicModel
    {
        [Key]
        public int TopicId { get; set; }
        public string TopicName { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastChangeTime { get; set; }

        public ICollection<ForumMessageModel> Messages { get; set; }
    }
}
