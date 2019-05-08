using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Fund
    {
        public int Id { get; set; }
        public decimal? SharingFund { get; set; }
        public int? SharingMember { get; set; }
        public decimal? SharingMinInCome { get; set; }
        public decimal? TravellingFund { get; set; }
        public int? TravellingMember { get; set; }
        public decimal? TravellingMinInCome { get; set; }
        public decimal? LuckyFund { get; set; }
        public int? LyckyMember { get; set; }
        public decimal? LuckyMinInCome { get; set; }
        public string FundSafe { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public decimal? SharingBonus { get; set; }
        public decimal? TravellingBonus { get; set; }
        public decimal? LuckyBonus { get; set; }
    }
}
