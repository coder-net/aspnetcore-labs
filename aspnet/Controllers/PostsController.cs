using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using aspnet.Data;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers
{
    public class PostsController : Controller
    {

        private readonly ApplicationDbContext _context;

        public PostsController(ApplicationDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.PostModels.ToList());
            //return View();
        }
    }
}