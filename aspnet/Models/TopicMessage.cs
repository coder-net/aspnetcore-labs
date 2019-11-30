using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class TopicMessage : Comment
    {
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
    }
}
