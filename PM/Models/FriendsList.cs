using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class FriendsList
    {
        public int UserId { get; set; }
        public int FriendUserId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
