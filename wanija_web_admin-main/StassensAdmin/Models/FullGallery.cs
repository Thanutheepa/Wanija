using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MotherSLAdmin.Models
{
    public class FullGallery
    {
        public Gallery gallery { get; set; }
        public List<GalleryItem> galleryImages { get; set; }
    }

    public class Gallery
    {
        public int galleryId { get; set; }
        public string Title { get; set; }
        public string mainImage { get; set; }
    }
    public class GalleryItem
    {
        public int galleryId { get; set; }
        public string imagePath { get; set; }
    }
}
