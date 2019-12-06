using aspnet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Data
{

    public interface IDBInitializer
    {
        void Initialize();
    }

    public class DbInitializer : IDBInitializer
    {
        private readonly Microsoft.AspNetCore.Identity.UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public DbInitializer(Microsoft.AspNetCore.Identity.UserManager<User> userManager
            , ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        public void Initialize()
        {
            _context.Database.EnsureCreated();

            if (_context.PostModels.Any())
            {
                return;
            }
            var user1 = new User();
            user1.Email = "a@gmail.com";
            _userManager.CreateAsync(user1, "Aa123!");
            //var user2 = new User();
            //user2.Email = "b@gmail.com";
            //_userManager.CreateAsync(user2, "Bb123!");
            //var user3 = new User();
            //user3.Email = "c@gmailc.om";
            //_userManager.CreateAsync(user3, "Cc123!");

            var posts = new Post[]
            {
                new Post("Some title", "text", user1, DateTime.Now),
                //new PostModel("<b>Bolt</b>"),
                //new PostModel("<h2>H2</h2>")
            };

            var comments = new PostComment[]
            {
                PostComment.Create("Comment", user1),
            };
            posts[0].Comments = comments;


            foreach (var post in posts)
            {
                _context.PostModels.Add(post);
            }


            
            _context.SaveChanges();
        }
    }
}
