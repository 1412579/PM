using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class CmsBanner
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string BannerName { get; set; }
        public int? BannerType { get; set; }
        public string Description { get; set; }
        public string ThumbnailImage { get; set; }
        public string LargeImage { get; set; }
        public string CoverImage { get; set; }
        public string TargetLink { get; set; }
        public string LinkRedirect { get; set; }
        public int? OrderNo { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
