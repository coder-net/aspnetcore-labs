using aspnet.Data;
using aspnet.Models;
using Markdig;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Hubs
{
    public class CommentsHub : Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public CommentsHub(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task SendMessage(string user, string text, string postId)
        {
            int id = Convert.ToInt16(postId);
            var post = _context.PostModels.Include(x => x.Comments).Where(a => a.PostId == id).First();
            if (post.Comments == null)
            {
                post.Comments = new List<PostComment>();
            }

            User AspNetUser = await _userManager.FindByNameAsync(user);
            DateTime creationTime = DateTime.Now;
            var commentary = new PostComment
            {
                CreationTime = creationTime,
                User = AspNetUser,
                UserId = AspNetUser.Id,
                UserName = AspNetUser.UserName,
                Text = text,
                Post = post,
                PostId = post.PostId,
            };

            post.Comments.Add(commentary);

            _context.PostModels.Update(post);

            _context.SaveChanges();
            var comment = _context.PostComments.Where(x => x.CreationTime == creationTime && x.Text == text).First();

            await Clients.All.SendAsync("ReceiveMessage", comment.Id.ToString(), user, Markdown.ToHtml(text), creationTime.ToString());

        }

        public async Task DeleteComment(string commentId)
        {
            int id = Convert.ToInt16(commentId);
            _context.PostComments.Remove(_context.PostComments.Find(id));
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("DeleteCommentFrom", id.ToString());
        }
    }
}
