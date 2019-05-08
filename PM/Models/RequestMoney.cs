using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class RequestMoney
    {
        public int Id { get; set; }
        public int? UserId { get; set; }
        public decimal? CurrentBalance { get; set; }
        public int? PaymentMethod { get; set; }
        public decimal? Amount { get; set; }
        public string BankName { get; set; }
        public string AccountNumber { get; set; }
        public string BankLocation { get; set; }
        public string AccountName { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Deleted { get; set; }
        public int? RequestType { get; set; }
    }
}
