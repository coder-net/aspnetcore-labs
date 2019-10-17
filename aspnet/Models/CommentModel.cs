using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class CommentModel
    {
        [Key]
        public int CommentId { get; set; }
        [Required]
        public IdentityUser User { get; set; }
        [Required]
        public string Text { get; set; }
        [Required, Column(TypeName="DateTime")]
        public DateTime CreationTime { get; set; }

        public int PostModelId { get; set; }
        public PostModel Post { get; set; }
    }
}
