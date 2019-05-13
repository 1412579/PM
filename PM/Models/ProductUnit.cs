using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class ProductUnit
    {
        public int UnitId { get; set; }
        public string UnitName { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
    }
}
