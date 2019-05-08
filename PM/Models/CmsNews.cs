using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class CmsNews
    {
        public long Id { get; set; }
        public long? CategoryId { get; set; }
        public string Title { get; set; }
        public string ImageThumb { get; set; }
        public string UrlRewrite { get; set; }
        public string ShortDescription { get; set; }
        public string BodyContent { get; set; }
        public string MetaKeyword { get; set; }
        public int? ViewCounter { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? PublishDate { get; set; }
        public DateTime? ExpirateDate { get; set; }
        public DateTime? PromoStartDate { get; set; }
        public DateTime? PromoExpireDate { get; set; }
        public bool? IsHot { get; set; }
        public byte? Status { get; set; }
        public int? OrderNo { get; set; }
        public string Tag { get; set; }
        public string SeoName { get; set; }
        public string MetaTitle { get; set; }
        public string MetaDescription { get; set; }
        public string CreateUser { get; set; }
        public long? ShareCount { get; set; }
    }
}
