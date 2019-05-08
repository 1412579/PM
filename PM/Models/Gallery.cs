using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Gallery
    {
        public long Id { get; set; }
        public string GalleryName { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public int? OrderNo { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
