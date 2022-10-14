using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Models
{
    public class Category
    {
        Category()
        {
            Posts = new List<Post>();
        }
        public int Id { get; set; }

        public string Title { get; set; }

        public string Slug { get; set; }

        public List<Post> Posts { get; set; }
    }
}