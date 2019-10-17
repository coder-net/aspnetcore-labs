using aspnet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Posts.Any())
            {
                return;
            }

            var posts = new PostModel[]
            {
                new PostModel("<h1>H1</h1>"),
                new PostModel("<b>Bolt</b>"),
                new PostModel("<h2>H2</h2>")
            };

            foreach (var post in posts)
            {
                context.Posts.Add(post);
            }

            context.SaveChanges();
        }
    }
}
