using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Comment
    {
        public int CommentId { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }
        public int? CommentFor { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsDeleted { get; set; }
    }
}
