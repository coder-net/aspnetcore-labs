using aspnet.Data;
using aspnet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet.Components
{
    public class RecentMessages : ViewComponent
    {
        ApplicationDbContext _context;
        UserManager<User> _userManager;

        public RecentMessages(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var messages = _context.TopicMessages.OrderByDescending(x => x.CreationTime).ToList();
            int i = 0;
            var list = new List<TopicMessage>();
            foreach (var message in messages)
            {
                if (i >= 10)
                    break;
                message.Topic = _context.TopicModels.Find(message.TopicId);
                message.User = await _userManager.FindByIdAsync(message.UserId);
                // list.Append(message);
                list.Add(message);
                ++i;

            }
            return View(list);
        }
    }
}
