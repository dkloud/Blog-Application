using BlogApp.BlogModels;
using BlogApp.UserModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.UserModels
{
    public class User
    {
        public User()
        {
            Blogs = new List<Blog>();
            Commentaries = new List<Commentary>();
        }
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        //public string Email { get; set; }

        public List<Blog> Blogs { get; set; }
        public List<Commentary> Commentaries { get; set; }

        public int? RoleId { get; set; }
        public Role Role { get; set; }
    }
}
