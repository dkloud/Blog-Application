using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BlogModels
{
    public class BlogArticle
    {
        public BlogArticle()
        {
            Commentaries = new List<Commentary>();
            Tags = new List<Tag>();
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public DateTime CreationDate { get; set; }

        public byte[] Image { get; set; }
        public string ImageContentType { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }

        public List<Commentary> Commentaries { get; set; }
        public List<Tag> Tags { get; set; }
    }
}
