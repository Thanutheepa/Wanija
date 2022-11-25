using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class BlogPosts
    {
        public int PostId { get; set; }
        public string MainImage { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string CreatedDate { get; set; }
        public string EditedDate { get; set; }
        public string SubDescription { get; set; }
    }
}
