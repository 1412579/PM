using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class Tour
    {
        public int Id { get; set; }
        public string TourName { get; set; }
        public string Content { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? StatusId { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? Deleted { get; set; }
    }
}
