using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.BlogModels;
using Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationContext _database;
        public HomeController(ApplicationContext applicationContext)
        {
            _database = applicationContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View(await _database.Blogs.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> ViewArticles(int? id)
        {
            if (id != null)
            {
                Blog blog = await _database.Blogs.Include(b => b.Articles).ThenInclude(ba => ba.Tags).FirstOrDefaultAsync(b => b.Id == id);
                if (blog != null)
                    return View(blog.Articles);
            }
            return NotFound();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
