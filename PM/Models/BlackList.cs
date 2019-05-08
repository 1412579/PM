using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class BlackList
    {
        public int UserId { get; set; }
        public int BlockUserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
