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
        public DbSet<Post> PostModels { get; set; }
        public DbSet<Topic> TopicModels { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();
            //this.Database.Migrate();
        }

        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //}

    
    }
}
