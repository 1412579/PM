using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class ChatRoom
    {
        public string RoomId { get; set; }
        public string RoomName { get; set; }
        public int? UserCreate { get; set; }
        public string Avatar { get; set; }
        public int? UserGuest { get; set; }
        public int? Type { get; set; }
        public int? UserCount { get; set; }
        public DateTime? CreateDate { get; set; }
        public string LastMessage { get; set; }
        public DateTime? LastDate { get; set; }
        public int? LastUser { get; set; }
        public int? LastType { get; set; }
    }
}
