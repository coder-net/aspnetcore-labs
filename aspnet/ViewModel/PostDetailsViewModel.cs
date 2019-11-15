using aspnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.ViewModel
{
    public class PostDetailsViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public User User { get; set; }
        public DateTime Time { get; set; }
        public string NewComment { get; set; }
        public ICollection<PostComment> Comments { get; set; }
        public bool IsAdmin { get; set; }

    }
}
