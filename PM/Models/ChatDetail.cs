using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class ChatDetail
    {
        public int Id { get; set; }
        public string RoomId { get; set; }
        public int? UserId { get; set; }
        public string Message { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
    }
}
