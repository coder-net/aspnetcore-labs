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
    public class PostsController : Controller
    {

        private readonly ApplicationDbContext _context;
        private readonly UserManager<User> _userManager;

        public PostsController(ApplicationDbContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            List<ShortPostViewModel> models = new List<ShortPostViewModel>();
            foreach (var post in _context.PostModels.ToList())
            {
                models.Add(new ShortPostViewModel
                {
                    PostId = post.PostId,
                    Title = post.Title,
                    Time = post.Time,
                    User = await _userManager.FindByIdAsync(post.UserId)
                });
            }
            return View(models);
        }
        [Authorize]
        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user is null)
                {
                    throw new InvalidOperationException("There is no current user.");
                }
                var post = new Post
                {
                    User = user,
                    Title = model.Title,
                    Text = model.Text,
                    Time = DateTime.Now,
                    Comments = null
                };
                if (String.IsNullOrWhiteSpace(model.Title) || String.IsNullOrWhiteSpace(model.Text))
                {
                    ModelState.AddModelError(String.Empty, "Both title and text must be provided.");
                }
                else
                {
                    await _context.PostModels.AddAsync(post);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> AddComment(PostDetailsViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(User.Identity.Name);
                if (user is null)
                {
                    throw new InvalidOperationException("There is no current user.");
                }
                Post post = await _context.PostModels.FindAsync(model.Id);
                if (String.IsNullOrWhiteSpace(model.NewComment))
                {
                    ModelState.AddModelError(String.Empty, "Comment must be provided.");
                }
                else
                {
                    var comment = new PostComment
                    {
                        User = user,
                        CreationTime = DateTime.Now,
                        Text = model.NewComment,
                        PostId = model.Id
                    };
                    if (post.Comments is null)
                    {
                        post.Comments = new List<PostComment>()
                        {
                            comment
                        };
                    }
                    else
                    {
                        post.Comments.Add(comment);
                    }
                    _context.PostComments.Add(comment);
                    _context.PostModels.Update(post);
                    await _context.SaveChangesAsync();
                }
            }
            return RedirectToAction("Details", new { id = model.Id });
        }

        public async Task<IActionResult> Details(int id)
        {
            Post post = await _context.PostModels.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            bool isAuntificated = User.Identity.IsAuthenticated;
            User user = null;
            if (isAuntificated)
                user = await _userManager.FindByNameAsync(User.Identity.Name);
            bool isAdmin = false;
            if (isAuntificated && (await _userManager.IsInRoleAsync(user, "admin") || user.Id == post.UserId))
                isAdmin = true;
            PostDetailsViewModel model = new PostDetailsViewModel
            {
                Id = post.PostId,
                Title = post.Title,
                Text = post.Text,
                Time = post.Time,
                User = await _userManager.FindByIdAsync(post.UserId),
                CurrentUser = await _userManager.GetUserAsync(HttpContext.User),
            Comments = _context.PostComments.Where(x => x.PostId == post.PostId).OrderByDescending(x => x.CreationTime).ToList(),
                IsAdmin = isAdmin
            };
            foreach (var comment in model.Comments)
            {
                comment.User = await _userManager.FindByIdAsync(comment.UserId);
            }
            return View(model);
        }

        public async Task<IActionResult> Edit(int id)
        {
            Post post = await _context.PostModels.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }
            EditPostViewModel model = new EditPostViewModel
            {
                Id = id,
                Title = post.Title,
                Text = post.Text
            };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EditPostViewModel model)
        {
            if (ModelState.IsValid)
            {
                Post post = await _context.PostModels.FindAsync(model.Id);
                if (post != null)
                {
                    post.Title = model.Title;
                    post.Text = model.Text;

                    var result = _context.PostModels.Update(post);
        
                    await _context.SaveChangesAsync();
                    return RedirectToAction("Details", new { id = post.PostId });
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
            Post post = await _context.PostModels.FindAsync(id);
            if (post != null)
            {
                var result = _context.PostModels.Remove(post);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction("Index");
        }


       

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

        public object GetPosts(int page, int perPage)
        {
            var albums = _context.PostModels.Include(x => x.User).OrderByDescending(x => x.Time);

            var count = albums.Count();
            var lastPage = Math.Ceiling((double)count / perPage);
            var data = new List<Object>();
            foreach (var post in albums.Skip((page - 1) * perPage).Take(perPage))
            {
                var date = post.Time.ToShortDateString();
                var userName = post.User.UserName;
                var title = Markdown.ToHtml(post.Title);
                var id = post.PostId;
                data.Add(new { title, date, userName, id});
            }
            return new { data, lastPage };
        }
    }
}