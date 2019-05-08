using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class ProductCategory
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Url { get; set; }
        public string Bimage { get; set; }
        public string Mimage { get; set; }
        public string Simage { get; set; }
        public int? Position { get; set; }
        public int? ParentId { get; set; }
        public string Description { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
