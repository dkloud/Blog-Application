using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BlogModels
{
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int BlogArticleId { get; set; }
        public BlogArticle BlogArticle { get; set; }

        public override bool Equals(object obj)
        {
            var item = obj as Tag;

            if (item == null)
            {
                return false;
            }

            return this.Name == item.Name;
        }

        public override int GetHashCode()
        {
            return this.Name.GetHashCode();
        }
    }

    //public class TagNameComparer : IEqualityComparer<Tag>
    //{
    //    public bool Equals(Tag x, Tag y)
    //    {
    //        if (string.Equals(x.Name, y.Name, StringComparison.OrdinalIgnoreCase))
    //        {
    //            return true;
    //        }
    //        return false;
    //    }

    //    public int GetHashCode(Tag obj)
    //    {
    //        return obj.Name.GetHashCode();
    //    }
    //}
}
