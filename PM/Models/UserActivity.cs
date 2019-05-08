using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class UserActivity
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public string UserName { get; set; }
        public string Avatar { get; set; }
        public int? PostId { get; set; }
        public string PostTitle { get; set; }
        public int? PostType { get; set; }
        public int? ActionType { get; set; }
        public string ActionName { get; set; }
        public string Ip { get; set; }
        public string Os { get; set; }
        public string Browser { get; set; }
        public int? UserIdpost { get; set; }
        public string UserNamePost { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Status { get; set; }
    }
}
