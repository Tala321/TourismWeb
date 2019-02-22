using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourismWebProject.Models
{
    public class BlogViewModel
    {
        public List<BlogPage> blogPage { get; set; }

        public List<BlogItem> blogItems { get; set; }

        public List<BlogDetail> blogDetails { get; set; }

        public List<BlogCategory> blogCategories { get; set; }

        public List<Tag> tags { get; set; }

        public List<Comment> comments { get; set; }
    }
}