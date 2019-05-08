using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Slug
    {
        public int Id { get; set; }
        public string SlugName { get; set; }
        public string HashSlug { get; set; }
        public int? Ref { get; set; }
        public string Controller { get; set; }
        public int? ObjectId { get; set; }
        public string RedirectUrl { get; set; }
        public int? Status { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
