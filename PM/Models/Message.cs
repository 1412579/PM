using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? ToUserId { get; set; }
        public string Title { get; set; }
        public string Message1 { get; set; }
        public int? StatusId { get; set; }
        public bool? Deleted { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
