using System;
using System.Collections.Generic;

namespace PM.Models
{
    public partial class ProductImport
    {
        public int ImportId { get; set; }
        public string ImportFrom { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        public bool? IsDelete { get; set; }
        public DateTime? ImportDate { get; set; }
        public DateTime? CreateDate { get; set; }
        public bool? IsActive { get; set; }
        public int ProductId { get; set; }
    }
}
