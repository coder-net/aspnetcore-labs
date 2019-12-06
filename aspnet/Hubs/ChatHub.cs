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
    public class ChatHub : Hub
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public ChatHub(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task SendMessage(string user, string message, string topicId)
          {
            int id = Convert.ToInt16(topicId);
            var topic = _context.TopicModels.Include(x => x.Messages).Where(a => a.Id == id).First();
            if (topic.Messages == null)
            {
                topic.Messages = new List<TopicMessage>();
            }

            User AspNetUser = await _userManager.FindByNameAsync(user);
            DateTime creationTime = DateTime.Now;
            var commentary = new TopicMessage
            {
                CreationTime = creationTime,
                User = AspNetUser,
                UserId = AspNetUser.Id,
                UserName = AspNetUser.UserName,
                Text = message,
                Topic = topic,
                TopicId = topic.Id,
            };

            topic.Messages.Add(commentary);

            _context.TopicModels.Update(topic);

            _context.SaveChanges();
            var comment = _context.TopicMessages.Where(x => x.CreationTime == creationTime && x.Text == message).First();

            await Clients.All.SendAsync("ReceiveMessage", comment.Id.ToString(), user, Markdown.ToHtml(message), DateTime.Now.ToString());

        }
        
        public async Task DeleteMessage(string messageId)
        {
            int id = Convert.ToInt16(messageId);
            _context.TopicMessages.Remove(_context.TopicMessages.Find(id));
            await _context.SaveChangesAsync();

            await Clients.All.SendAsync("DeleteMessageFrom", id.ToString());
        }

    }
}
