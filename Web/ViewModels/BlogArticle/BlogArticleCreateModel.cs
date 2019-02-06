using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web.ViewModels.BlogArticle
{
    public class BlogArticleCreateModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int BlogId { get; set; }

        public IFormFile Image { get; set; }

        public string TagsInput { get; set; }
    }
}
