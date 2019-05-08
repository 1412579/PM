using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class PostReport
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public string Content { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
    }
}
