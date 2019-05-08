using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class PostShare
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public int? UserId { get; set; }
        public int? Type { get; set; }
    }
}
