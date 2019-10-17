using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class PostModel
    {
        public PostModel(string text)
        {
            this.Text = text;
        }

        [Key]
        public int PostId { get; set; }
        [Required]
        public IdentityUser User { get; set; }
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        public ICollection<CommentModel> Comments { get; set; }
    }
}
