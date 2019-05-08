using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Like
    {
        public int LikeId { get; set; }
        public int? UserId { get; set; }
        public string FullName { get; set; }
        public int? PostId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
