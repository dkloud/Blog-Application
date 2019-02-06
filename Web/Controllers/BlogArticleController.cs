using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BlogApp.BlogModels;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.ViewModels;
using Web.ViewModels.BlogArticle;

namespace Web.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class BlogArticleController : Controller
    {
        private readonly ApplicationContext _database;
        public BlogArticleController(ApplicationContext applicationContext)
        {
            _database = applicationContext;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Index(int? id) //BlogId
        {
            if (id != null)
            {
                Blog blog = await _database.Blogs.Include(b => b.Articles).Include(b => b.User).FirstOrDefaultAsync(b => b.Id == id);
                if (blog != null)
                {
                    ViewBag.UserLogin = blog.User.Login;
                    ViewBag.BlogId = blog.Id;
                    return View(blog.Articles);
                }
            }
            return NotFound();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FilterByText(string search)
        {
            if (!String.IsNullOrEmpty(search))
            {
                IEnumerable<BlogArticle> blogArticles = await _database.BlogArticles.
                    Where(b => b.Text.Contains(search) || b.Name.Contains(search)).ToListAsync();
                return View("Index", blogArticles);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> FilterByTags(string tags)
        {
            if (!String.IsNullOrEmpty(tags))
            {
                string[] search = tags.Split(',');
                List<Tag> tagsList = new List<Tag>();
                foreach (var item in search)
                {
                    tagsList.Add(new Tag { Name = item });
                }
                //IEnumerable<BlogArticle> blogArticles = _database.BlogArticles.
                //    Include(b => b.Tags).
                //    Where(b => b.Tags.Intersect(tagsList, new TagNameComparer()).Any()).ToList(); ///// Not supported ;( //////
                IEnumerable<BlogArticle> blogArticles = await _database.BlogArticles.
                    Include(b => b.Tags).
                    Where(b => b.Tags.Intersect(tagsList).Any()).ToListAsync();
                return View("Index", blogArticles);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Create(int? id)//BlogId
        {
            if (id != null)
            {
                Blog blog = _database.Blogs.Include(b => b.User).FirstOrDefault(b => b.Id == id);
                if (blog != null)
                {
                    if (BlogHelper.VerifyAuther(blog?.User?.Login, User))
                    {
                        ViewBag.BlogId = id;
                        return View();
                    }
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Create(BlogArticleCreateModel model)
        {
            BlogArticle blogArticle = new BlogArticle();
            blogArticle.Name = model.Name;
            blogArticle.Text = model.Text;
            blogArticle.CreationDate = DateTime.Now;

            string[] tags = null;
            if (!String.IsNullOrEmpty(model.TagsInput))
            {
                tags = model.TagsInput.Split(',');
            }
            if (tags != null)
            {
                foreach (var item in tags)
                {
                    blogArticle.Tags.Add(new Tag { Name = item });
                }
            }

            if (model.Image != null)
            {
                blogArticle.Image = BlogHelper.ImageToByteArray(model.Image);
                blogArticle.ImageContentType = model.Image.ContentType;
            }

            Blog blog = _database.Blogs.Include(b => b.Articles).FirstOrDefault(b => b.Id == model.BlogId);
            blog.Articles.Add(blogArticle);
            //_database.BlogArticles.Add(blogArticle);
            await _database.SaveChangesAsync();
            return RedirectToAction("Index", "BlogArticle", new { id = blog.Id });
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                BlogArticle blogArticle = await _database.BlogArticles.
                    Include(b => b.Tags).
                    Include(b => b.Blog).
                    ThenInclude(b => b.User).
                    FirstOrDefaultAsync(b => b.Id == id);
                if (blogArticle != null)
                {
                    if (BlogHelper.VerifyOperation(blogArticle?.Blog?.User?.Login, User, DataOperation.Edit))
                        return View(blogArticle);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(BlogArticleEditModel model)
        {
            BlogArticle blogArticle = _database.BlogArticles.FirstOrDefault(b => b.Id == model.Id);
            blogArticle.Name = model.Name;
            blogArticle.Text = model.Text;

            string[] tags = null;
            if (!String.IsNullOrEmpty(model.TagsInput))
            {
                tags = model.TagsInput.Split(',');
            }
            if (tags != null)
            {
                foreach (var item in tags)
                {
                    blogArticle.Tags.Add(new Tag { Name = item });
                }
            }

            if (model.Image != null)
            {
                blogArticle.Image = BlogHelper.ImageToByteArray(model.Image);
                blogArticle.ImageContentType = model.Image.ContentType;
            }
            await _database.SaveChangesAsync();
            return RedirectToAction("Details", "BlogArticle", new { id = blogArticle.Id });
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                BlogArticle blogArticle = await _database.BlogArticles.
                    Include(b => b.Blog).
                    ThenInclude(b => b.User).
                    FirstOrDefaultAsync(b => b.Id == id);
                if (blogArticle != null)
                {
                    if (BlogHelper.VerifyOperation(blogArticle?.Blog?.User?.Login, User, DataOperation.Delete))
                        return View(blogArticle);
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            BlogArticle blogArticle = new BlogArticle { Id = id.Value };
            _database.Entry(blogArticle).State = EntityState.Deleted;
            await _database.SaveChangesAsync();
            return RedirectToAction("Index", "Blog");
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id != null)
            {
                BlogArticle blogArticle = await _database.BlogArticles.
                    Include(b => b.Tags).
                    Include(b => b.Commentaries).
                    Include(b => b.Blog).
                    ThenInclude(b => b.User).
                    FirstOrDefaultAsync(b => b.Id == id);
                if (blogArticle != null)
                    return View(blogArticle);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Details(int? id, string commentary)
        {
            if (id != null)
            {
                BlogArticle blogArticle = await _database.BlogArticles.Include(b => b.Commentaries).FirstOrDefaultAsync(b => b.Id == id);
                if (blogArticle != null)
                {
                    blogArticle.Commentaries.Add(new Commentary
                    { Username = User.Identity.Name, Text = commentary, CreationDate = DateTime.Now, BlogArticleId = blogArticle.Id });
                    _database.Update(blogArticle);
                    await _database.SaveChangesAsync();
                    return RedirectToAction("Details", "BlogArticle", new { id = blogArticle.Id });
                }
            }
            return NotFound();
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ViewBlogImage(int? id)
        {
            if (id != null)
            {
                BlogArticle blogArticle = await _database.BlogArticles.FirstOrDefaultAsync(b => b.Id == id);
                if (blogArticle != null)
                {
                    var image = blogArticle.Image;
                    if (image.Length > 0)
                    {
                        MemoryStream memoryStream = new MemoryStream(image);
                        return new FileStreamResult(memoryStream, blogArticle.ImageContentType);
                    }
                }
            }
            return null;
        }
    }
}