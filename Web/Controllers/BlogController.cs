using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using BlogApp.BlogModels;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using BlogApp.UserModels;
using Web.Models;
using Web.ViewModels.Blog;

namespace Web.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class BlogController : Controller
    {
        private readonly ApplicationContext _database;
        public BlogController(ApplicationContext applicationContext)
        {
            _database = applicationContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(string user)
        {
            if (string.IsNullOrEmpty(user))
                return View(await _database.Blogs.ToListAsync());
            else
                return View(await _database.Blogs.Include(b => b.User).Where(b => b.User.Login == User.Identity.Name).ToListAsync());
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FilterByText(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                IEnumerable<Blog> blogs = await _database.Blogs.Where(b => b.Description.Contains(search) || b.Name.Contains(search)).ToListAsync();
                return View("Index", blogs);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Blog blog)
        {
            var currentUser = _database.Users.FirstOrDefault(u => u.Login == User.Identity.Name);
            blog.CreationDate = DateTime.Now;
            blog.UserId = currentUser.Id;
            _database.Blogs.Add(blog);
            await _database.SaveChangesAsync();
            return RedirectToAction("Details", "Blog", new { id = blog.Id});
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Blog blog = await _database.Blogs.Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
                if (blog != null)
                {
                    if (BlogHelper.VerifyOperation(blog?.User?.Login, User, DataOperation.Edit))
                        return View(blog);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogModel model)
        {
            Blog blog = _database.Blogs.FirstOrDefault(b => b.Id == model.Id);
            blog.Name = model.Name;
            blog.Description = model.Description;
            //_database.Blogs.Update(blog);
            await _database.SaveChangesAsync();
            return RedirectToAction("Details", "Blog", new { id = blog.Id });
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Blog blog = await _database.Blogs.Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
                if (blog != null)
                {
                    if (BlogHelper.VerifyOperation(blog?.User?.Login, User, DataOperation.Delete))
                        return View(blog);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            Blog blog = new Blog { Id = id.Value };
            _database.Entry(blog).State = EntityState.Deleted;
            await _database.SaveChangesAsync();
            return RedirectToAction("Index", "Blog");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                Blog blog = await _database.Blogs.Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
                if (blog != null)
                    return View(blog);
            }
            return NotFound();
        }
    }
}

