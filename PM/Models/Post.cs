using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Post
    {
        public int PostId { get; set; }
        public int? UserId { get; set; }
        public string Title { get; set; }
        public int? PostType { get; set; }
        public string Image { get; set; }
        public string WebLink { get; set; }
        public string YoutubeLink { get; set; }
        public string Content { get; set; }
        public int? Comment { get; set; }
        public int? Like { get; set; }
        public bool? IsActived { get; set; }
        public bool? IsDeleted { get; set; }
        public int? UserDeleted { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? UserCreate { get; set; }
        public int? ShareId { get; set; }
        public int? ShareType { get; set; }
        public long? ShareCount { get; set; }
    }
}
