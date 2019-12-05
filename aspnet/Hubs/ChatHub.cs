using aspnet.Data;
using aspnet.Models;
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
            AddCommentary(topic, message, user);


            _context.TopicModels.Update(topic);
            
            await Clients.All.SendAsync("ReceiveMessage", user, message, DateTime.Now.ToString());

            await _context.SaveChangesAsync();
        }

        public async void AddCommentary(Topic topic, string NewCommentary, string UserName)
        {
            User AspNetUser = await _userManager.FindByNameAsync(UserName);
            var commentary = new TopicMessage
            {
                CreationTime = DateTime.Now,
                User = AspNetUser,
                UserId = AspNetUser.Id,
                UserName = AspNetUser.UserName,
                Text = NewCommentary,
                Topic = topic,
                TopicId = topic.Id,
            };

            topic.Messages.Add(commentary);
        }

    }
}
