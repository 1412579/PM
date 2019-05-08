using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class UserLog
    {
        public int LogId { get; set; }
        public int? UserId { get; set; }
        public decimal? Token { get; set; }
        public string Note { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
