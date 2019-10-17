using System;
using System.Collections.Generic;
using System.Text;
using aspnet.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<TopicModel>()
                .Property(u => u.CreationTime)
                .HasComputedColumnSql("GETDATE()");

            builder.Entity<ForumMessageModel>()
                .Property(u => u.CreationTime)
                .HasComputedColumnSql("GETDATE()");

            builder.Entity<CommentModel>()
                .Property(u => u.CreationTime)
                .HasComputedColumnSql("GETDATE()");

            builder.Entity<CommentModel>()
                .HasOne<PostModel>(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostModelId);

            builder.Entity<ForumMessageModel>()
                .HasOne<TopicModel>(m => m.Topic)
                .WithMany(t => t.Messages)
                .HasForeignKey(m => m.TopicId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public DbSet<PostModel> Posts { get; set; }
        public DbSet<TopicModel> Topics { get; set; }
        public DbSet<ForumMessageModel> ForumMessages { get; set; }
        public DbSet<CommentModel> Comments { get; set; }
    }
}
