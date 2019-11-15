using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class PostComment : Comment
    {
        public static PostComment Create(string text, User user)
        {
            var obj = new PostComment();
            obj.User = user;
            obj.Text = text;
            obj.CreationTime = DateTime.Now;
            return obj;
        }
        public int PostId { get; set; }
        [ForeignKey("PostId")]
        public Post Post { get; set; }

    }
}
