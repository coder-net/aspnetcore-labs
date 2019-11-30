using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Data;
using aspnet.Models;
using aspnet.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
                User = await _userManager.FindByIdAsync(topic.UserId),
                Messages = _context.TopicMessages.Where(x => x.Id == topic.Id).OrderBy(x => x.CreationTime).ToList(),
                IsAdmin = isAdmin
            };
            return View(model);
        }

        //public async Task<ActionResult> AddComment(DiscussViewModel model)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        User user = await _userManager.FindByNameAsync(User.Identity.Name);
        //        if (user is null)
        //        {
        //            throw new InvalidOperationException("There is no current user.");
        //        }
        //        Post post = await _context.PostModels.FindAsync(model.Id);
        //        if (String.IsNullOrWhiteSpace(model.NewComment))
        //        {
        //            ModelState.AddModelError(String.Empty, "Comment must be provided.");
        //        }
        //        else
        //        {
        //            var comment = new PostComment
        //            {
        //                User = user,
        //                CreationTime = DateTime.Now,
        //                Text = model.NewComment,
        //                PostId = model.Id
        //            };
        //            if (post.Comments is null)
        //            {
        //                post.Comments = new List<PostComment>()
        //                {
        //                    comment
        //                };
        //            }
        //            else
        //            {
        //                post.Comments.Add(comment);
        //            }
        //            _context.PostComments.Add(comment);
        //            _context.PostModels.Update(post);
        //            await _context.SaveChangesAsync();
        //        }
        //    }
        //    return RedirectToAction("Details", new { id = model.Id });
        //}


        public async Task<IActionResult> EditComment(int id)
        {
            var comment = await _context.PostComments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            var model = new EditCommentViewModel
            {
                Id = id,
                Text = comment.Text
            };
            return View("EditComment", model);
        }

        [HttpPost]
        public async Task<IActionResult> EditComment(EditPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                var comment = await _context.PostComments.FindAsync(model.Id);
                if (comment != null)
                {
                    comment.Text = model.Text;

                    var result = _context.PostComments.Update(comment);

                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = comment.PostId });
                }
            }
            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> DeleteComment(int id)
        {
            var comment = await _context.PostComments.FindAsync(id);
            if (comment != null)
            {
                int postId = comment.PostId;
                var result = _context.PostComments.Remove(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction("Details", new { id = postId });
            }
            else
            {
                return RedirectToAction("Index");
            }

        }
    }
}