using aspnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.ViewModel
{
    public class ShortPostViewModel
    {
        public int PostId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public DateTime Time { get; set; }
    }
}
