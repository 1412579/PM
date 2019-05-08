using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Transfer
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public decimal? CurrentBalanceUserId { get; set; }
        public int? ToUserId { get; set; }
        public decimal? CurrentBalanceToUserId { get; set; }
        public decimal? Amount { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UserName { get; set; }
        public string ToUserName { get; set; }
    }
}
