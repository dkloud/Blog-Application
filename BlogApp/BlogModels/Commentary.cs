using BlogApp.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BlogModels
{
    public class Commentary
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public string Username { get; set; }

        public int BlogArticleId { get; set; }
        public BlogArticle BlogArticle { get; set; }
    }
}
