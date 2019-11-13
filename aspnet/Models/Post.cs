using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class Post
    {
        public Post(string text)
        {
            this.Text = text;
            this.Comments = null;
        }

        public Post(string text, User user) : this(text)
        {
            this.User = user;
            this.Time = DateTime.Now;
            this.Comments = null;
        }

        [Key]
        public int PostId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        public ICollection<Comment<Post>> Comments { get; set; }
    }
}
