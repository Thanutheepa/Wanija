using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class ItemImages
    {
        public int imageId { get; set; }
        public int itemId { get; set; }
        public List<string> imagePath { get; set; }
    }
}
