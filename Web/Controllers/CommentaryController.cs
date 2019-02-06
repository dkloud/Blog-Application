using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.BlogModels;
using Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web.Models;
using Web.ViewModels.Commentary;

namespace Web.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class CommentaryController : Controller
    {
        private readonly ApplicationContext _database;
        public CommentaryController(ApplicationContext applicationContext)
        {
            _database = applicationContext;
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)// Commentary id
        {
            if (id != null)
            {
                //Commentary commentary = await _database.Commentaries.
                //    Include(c => c.BlogArticle).
                //    ThenInclude(b => b.Blog).
                //    ThenInclude(b => b.User).
                //    FirstOrDefaultAsync(c => c.Id == id);
                Commentary commentary = await _database.Commentaries.Include(c => c.BlogArticle).FirstOrDefaultAsync(c => c.Id == id);
                if (commentary != null)
                {
                    if (BlogHelper.VerifyAuther(commentary?.Username, User))
                    {
                        return View(commentary);
                    }
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CommentaryModel model)
        {
            Commentary commentary = _database.Commentaries.FirstOrDefault(c => c.Id == model.Id);
            commentary.Text = model.Text + " [edited]";
            commentary.CreationDate = DateTime.Now;

            await _database.SaveChangesAsync();
            //return RedirectToAction("Details", "BlogArticle", new { id = commentary.BlogArticleId });
            return Redirect(Url.Action("Details", "BlogArticle", new { id =  commentary.BlogArticleId}) + "#commentary-section");
        }

        [HttpGet]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(int? id)
        {
            if (id != null)
            {
                Commentary commentary = await _database.Commentaries.Include(c => c.BlogArticle).FirstOrDefaultAsync(c => c.Id == id);
                if (commentary != null)
                {
                    if (BlogHelper.VerifyAuther(commentary?.Username, User))
                    {
                        return View(commentary);
                    }
                }
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id, int? blogArticleId)
        {
            Commentary commentary = new Commentary { Id = id.Value };
            _database.Entry(commentary).State = EntityState.Deleted;
            await _database.SaveChangesAsync();
            return Redirect(Url.Action("Details", "BlogArticle", new { id = blogArticleId }) + "#commentary-section");
        }

    }
}