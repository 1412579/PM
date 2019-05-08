using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class NotifyHistory
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int? PostId { get; set; }
        public string Content { get; set; }
        public int? ImageCount { get; set; }
        public DateTime? NotifyDate { get; set; }
        public int? ActionFromId { get; set; }
        public string Action { get; set; }
        public int? PostType { get; set; }
        public string Link { get; set; }
        public string Image { get; set; }
    }
}
