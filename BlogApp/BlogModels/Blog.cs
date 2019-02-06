using BlogApp.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BlogModels
{
    public class Blog
    {
        public Blog()
        {
            Articles = new List<BlogArticle>();
        }
        public int Id { get; set; }
        public string Name { get; set; }   
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public List<BlogArticle> Articles { get; set; }
    }
}
