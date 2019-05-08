using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Products
    {
        public long ProductId { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public string SeoName { get; set; }
        public int? CategoryId { get; set; }
        public string Simage { get; set; }
        public string Mimage { get; set; }
        public string Bimage { get; set; }
        public decimal? Price { get; set; }
        public decimal? SalePrice { get; set; }
        public string Promotion { get; set; }
        public string ShortDescription { get; set; }
        public string DetailContent { get; set; }
        public string MetaTitle { get; set; }
        public string MetaKeyword { get; set; }
        public string MetaDescription { get; set; }
        public bool? IsNew { get; set; }
        public bool? IsHot { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? ViewCount { get; set; }
        public string Url { get; set; }
        public bool? IsActive { get; set; }
        public decimal? BonusPercent { get; set; }
        public int? Warranty { get; set; }
        public string PartnerLink { get; set; }
        public bool? IsTarget { get; set; }
        public string CreateUser { get; set; }
        public int? ViewDoping { get; set; }
        public long? ShareCount { get; set; }
        public decimal? TokenPrice { get; set; }
    }
}
