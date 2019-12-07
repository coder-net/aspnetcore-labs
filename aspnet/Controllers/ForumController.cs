using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Data;
using aspnet.Models;
using aspnet.ViewModel;
using Markdig;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace aspnet.Controllers
{
    public class ForumController : Controller
    {
        ApplicationDbContext _context;
        UserManager<User> _userManager;

        public ForumController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        
        public IActionResult Index()
        {
            return View(_context.TopicModels.ToList());
        }

        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Create(CreateTopicViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user is null)
                {
                    throw new InvalidOperationException("There is no current user.");
                }
                if (String.IsNullOrWhiteSpace(model.Name) || String.IsNullOrWhiteSpace(model.Description))
                {
                    ModelState.AddModelError(String.Empty, "Both title and text must be provided.");
                }
                else
                {
                    var topic = new Topic()
                    {
                        User = user,
                        Name = model.Name,
                        Description = model.Description,
                        CreationTime = DateTime.Now,
                        LastChangeTime = DateTime.Now,
                        Messages = null
                    };
                    await _context.TopicModels.AddAsync(topic);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Discuss(int id)
        {
            //var topic = _context.TopicModels.Include(x => x.Messages).FirstOrDefault(x => x.Id == id);//.FindAsync(id);
            var topic = await _context.TopicModels.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            bool isAuntificated = User.Identity.IsAuthenticated;
            User user = null;
            if (isAuntificated)
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            bool isAdmin = false;
            if (isAuntificated && (await _userManager.IsInRoleAsync(user, "admin") || user.Id == topic.UserId))
                isAdmin = true;
            var model = new DiscussViewModel
            {
                Id = topic.Id,
                Name = topic.Name,
                Description = topic.Description,
                CreationTime = topic.CreationTime,
                User = user,
                Messages = _context.TopicMessages.Where(x => x.TopicId == topic.Id).OrderBy(x => x.CreationTime).ToList(),
                IsAdmin = isAdmin
            };
            foreach (var message in model.Messages)
            {
                message.User = await _userManager.FindByIdAsync(message.UserId);
            }
            return View(model);
        }

        public async Task<IActionResult> EditMessage(int id)
        {
            var message = await _context.TopicMessages.FindAsync(id);
            if (message == null)
            {
                return NotFound();
            }
            var model = new EditCommentViewModel
            {
                Id = id,
                Text = message.Text
            };
            return View("EditComment", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditMessage(EditPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var message = await _context.TopicMessages.FindAsync(model.Id);
                if (message != null)
                {
                    message.Text = model.Text;

                    var result = _context.TopicMessages.Update(message);

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Discuss", new { id = message.TopicId });
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Topic topic = await _context.TopicModels.FindAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            EditPostViewModel model = new EditPostViewModel
            {
                Id = id,
                Title = topic.Name,
                Text = topic.Description,
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                Topic topic = await _context.TopicModels.FindAsync(model.Id);
                if (topic != null)
                {
                    topic.Name = model.Title;
                    topic.Description = model.Text;

                    var result = _context.TopicModels.Update(topic);

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Discuss", new { id = topic.Id });
                }
                else
                {

                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            Topic topic = await _context.TopicModels.FindAsync(id);
            if (topic != null)
            {
                var result = _context.TopicModels.Remove(topic);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }

        public object GetTopics(int page, int perPage)
        {
            var albums = _context.TopicModels.Include(x => x.User).OrderByDescending(x => x.CreationTime);

            var count = albums.Count();
            var lastPage = Math.Ceiling((double)count / perPage);
            var data = new List<Object>();
            foreach (var post in albums.Skip((page - 1) * perPage).Take(perPage))
            {
                var name = Markdown.ToHtml(post.Name);
                var description = Markdown.ToHtml(post.Description);
                var id = post.Id;
                data.Add(new { name, description, id });
            }
            return new { data, lastPage };
        }
    }
}