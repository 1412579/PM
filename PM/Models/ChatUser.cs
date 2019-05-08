using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class ChatUser
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string RoomId { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
