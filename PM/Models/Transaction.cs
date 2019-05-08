using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Transaction
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public int? IdRef { get; set; }
        public int? TransactionType { get; set; }
        public int? Status { get; set; }
        public decimal? LastBalance { get; set; }
        public decimal? LastIncome { get; set; }
        public decimal? Balance { get; set; }
        public decimal? Income { get; set; }
        public string TransactionSafe { get; set; }
        public DateTime? CreateDate { get; set; }
        public decimal? Amount { get; set; }
        public string Note { get; set; }
    }
}
