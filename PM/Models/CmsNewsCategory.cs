using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class CmsNewsCategory
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
        public long? ParentId { get; set; }
        public string UrlRewrite { get; set; }
        public string IconImg { get; set; }
        public string Description { get; set; }
        public int? OrderNo { get; set; }
        public bool? IsActive { get; set; }
    }
}
