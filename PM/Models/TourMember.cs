using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class TourMember
    {
        public int Id { get; set; }
        public int? TourId { get; set; }
        public int? UserId { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
