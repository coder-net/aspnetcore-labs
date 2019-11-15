﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Models
{
    public class Comment<T>
    {
        public static Comment<T> Create(string text, User user, int parentId)
        {
            var obj = new Comment<T>();
            obj.User = user;
            obj.Text = text;
            obj.CreationTime = DateTime.Now;
            obj.ParentId = parentId;
            return obj;
        }
        [Key]
        public int CommentId { get; set; }
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime CreationTime { get; set; }
        public int ParentId { get; set; }
    }
}
