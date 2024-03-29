﻿using System;
using System.Collections.Generic;
using System.Text;
using aspnet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Post> PostModels { get; set; }
        public DbSet<Topic> TopicModels { get; set; }
        public DbSet<PostComment> PostComments { get; set; }
        public DbSet<TopicMessage> TopicMessages { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //this.Database.Migrate();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Post>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Post>()
               .HasMany(x => x.Comments)
               .WithOne(x => x.Post)
               .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<PostComment>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<TopicMessage>()
                .HasOne(x => x.User)
                .WithMany()
                .OnDelete(DeleteBehavior.Restrict);


            //builder.Entity<Topic>()
            //    .HasMany(x => x.Messages)
            //    .WithOne(x => x.ParentId)
            //    .OnDelete(DeleteBehavior.Cascade);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

    
    }
}
