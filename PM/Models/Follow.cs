using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Follow
    {
        public int UserId { get; set; }
        public int FollowUserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
