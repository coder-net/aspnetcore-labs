﻿using Microsoft.AspNetCore.Identity;
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
        public Post() { }
        public Post(string title, DateTime time)
        {
            this.Title = title;
            this.Time = time;
            this.Comments = new List<PostComment>();
        }

        public Post(string title, string text, User user, DateTime time)
        {
            this.Title = title;
            this.Text = text;
            this.User = user;
            this.Time = time;
            this.Comments = new List<PostComment>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int PostId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime Time { get; set; }

        public ICollection<PostComment> Comments { get; set; }
    }
}
