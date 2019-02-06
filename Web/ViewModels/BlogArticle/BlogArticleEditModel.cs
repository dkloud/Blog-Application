using BlogApp.BlogModels;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.BlogArticle
{
    public class BlogArticleEditModel
    {
        [Required]
        public int Id { get; set; }


        public string Name { get; set; }


        public string Text { get; set; }

        public IFormFile Image { get; set; }

        public string TagsInput { get; set; }

        //public List<Commentary> Commentaries { get; set; }
        //public List<Tag> Tags { get; set; }
    }
}
