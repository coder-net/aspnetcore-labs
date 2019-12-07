using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace aspnet.Controllers
{
    public class ActivityController : Controller
    {
        [HttpGet("/Activity")]
        public IActionResult Index()
        {
            return View();
        }
    }
}